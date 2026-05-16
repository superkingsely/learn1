# LINQ Exercise Solutions - Restaurant Report Service

Optimized solutions for each exercise. All solutions follow best practices for database scenarios (EF Core / LINQ-to-SQL) to minimize data fetching and improve performance.

---

## Exercise 1 — Basic Filter

**Question:** Get all paid, non-void orders from "rc1" (Main Hall) between Jan 10 and Jan 11 2025.

**Solution (Method Syntax - Recommended):**
```csharp
var startDate = new DateTime(2025, 1, 10);
var endDate = new DateTime(2025, 1, 11, 23, 59, 59);

var rc1Orders = orders
    .Where(o => o.IsPaid && !o.IsVoid)
    .Where(o => o.RevenueCenterId == "rc1")
    .Where(o => o.DateCreated >= startDate && o.DateCreated <= endDate)
    .Select(o => new
    {
        StaffName = $"{o.CreatedBy.FirstName} {o.CreatedBy.LastName}",
        o.TotalAmount,
        o.DateCreated
    })
    .OrderBy(o => o.DateCreated)
    .ToList();
```

**Why this way:**
- Filters (`Where`) are applied **before** projection (`Select`) to reduce data early
- Multiple `Where` clauses allow the query provider to combine them into a single SQL `WHERE`
- Only necessary fields are projected (`StaffName`, `TotalAmount`, `DateCreated`)
- For databases, this translates to:  
  `SELECT CONCAT(FirstName, ' ', LastName) AS StaffName, TotalAmount, DateCreated FROM Orders WHERE IsPaid = 1 AND IsVoid = 0 AND RevenueCenterId = 'rc1' AND DateCreated BETWEEN @start AND @end ORDER BY DateCreated`

**Result:**

| StaffName | TotalAmount | DateCreated |
|-----------|-------------|------------|
| Alice Smith | 3800 | 2025-01-10 12:00:00 |
| Alice Smith | 2000 | 2025-01-11 14:00:00 |

---

## Exercise 2 — Aggregation

**Question:** From all paid orders, calculate total revenue, total guest count, average spend per order, and how many were discounted.

**Solution:**
```csharp
var paidOrders = orders
    .Where(o => o.IsPaid)
    .ToList(); // Materialize once to avoid multiple enumeration

var totalRevenue = paidOrders.Sum(o => o.TotalAmount);
var totalGuests = paidOrders.Sum(o => o.GuestCount);
var orderCount = paidOrders.Count;
var averageSpend = orderCount > 0 ? totalRevenue / orderCount : 0;
var discountedCount = paidOrders.Count(o => o.IsDiscounted);
```

**Alternative (single query with aggregate functions):**
```csharp
var operationStats = orders
    .Where(o => o.IsPaid)
    .GroupBy(o => 1) // Group all into one group
    .Select(g => new
    {
        TotalRevenue = g.Sum(o => o.TotalAmount),
        TotalGuests = g.Sum(o => o.GuestCount),
        OrderCount = g.Count(),
        AverageSpend = g.Average(o => o.TotalAmount),
        DiscountedCount = g.Count(o => o.IsDiscounted)
    })
    .FirstOrDefault();
```

**Why this way:**
- `Sum`, `Count`, `Average` with predicates are translated to SQL aggregate functions (`SUM()`, `COUNT()`, `AVG()`)
- Grouping by a constant (or using a single `Select`) allows computing multiple aggregates in one query
- For databases, the alternative approach becomes:  
  `SELECT SUM(TotalAmount) AS TotalRevenue, SUM(GuestCount) AS TotalGuests, COUNT(*) AS OrderCount, AVG(TotalAmount) AS AverageSpend, COUNT(CASE WHEN IsDiscounted = 1 THEN 1 END) AS DiscountedCount FROM Orders WHERE IsPaid = 1`
- This is **much more efficient** than loading all rows into memory

**Result:**

| TotalRevenue | TotalGuests | OrderCount | AverageSpend | DiscountedCount |
|-------------|-------------|------------|--------------|-----------------|
| 14200 | 8 | 4 | 3550 | 1 |

---

## Exercise 3 — GroupBy Staff

**Question:** Group paid orders by staff member. For each staff, show full name, number of orders, and total sales amount.

**Solution:**
```csharp
var salesByStaff = orders
    .Where(o => o.IsPaid)
    .GroupBy(o => new
    {
        o.CreatedBy.Id,
        FullName = $"{o.CreatedBy.FirstName} {o.CreatedBy.LastName}"
    })
    .Select(g => new
    {
        StaffName = g.Key.FullName,
        OrderCount = g.Count(),
        TotalSales = g.Sum(o => o.TotalAmount)
    })
    .OrderByDescending(s => s.TotalSales)
    .ToList();
```

**Why this way:**
- `GroupBy` uses an anonymous object with `Id` and `FullName` to ensure correct grouping (in case two staff share a name)
- Aggregation (`Count`, `Sum`) happens in the `Select` after grouping—this translates to SQL `GROUP BY` with aggregate functions
- `OrderByDescending` sorts after aggregation, which is more efficient than sorting before grouping
- For databases:  
  `SELECT CreatedById, CONCAT(FirstName, ' ', LastName) AS StaffName, COUNT(*) AS OrderCount, SUM(TotalAmount) AS TotalSales FROM Orders WHERE IsPaid = 1 GROUP BY CreatedById, FirstName, LastName ORDER BY TotalSales DESC`

**Result:**

| StaffName | OrderCount | TotalSales |
|-----------|------------|------------|
| Bob Jones | 2 | 8400 |
| Alice Smith | 2 | 5800 |

---

## Exercise 4 — GroupBy Item Class

**Question:** From `allItemOrders`, group by `Item.ItemClassName`. For each class show total quantity sold, total gross sales, cost of goods, and gross profit.

**Solution:**
```csharp
var salesByClass = allItemOrders
    .Where(io => !io.IsRefunded) // Exclude refunded items
    .GroupBy(io => io.Item.ItemClassName)
    .Select(g => new
    {
        ClassName = g.Key,
        TotalQuantity = g.Sum(io => io.Quantity),
        TotalGrossSales = g.Sum(io => io.Amount),
        CostOfGoods = g.Sum(io => (decimal)io.Quantity * io.Item.CostPrice),
        GrossProfit = g.Sum(io => io.Amount) - g.Sum(io => (decimal)io.Quantity * io.Item.CostPrice)
    })
    .OrderByDescending(c => c.TotalGrossSales)
    .ToList();
```

**Why this way:**
- Filter out refunded items early to avoid counting them
- `GroupBy` groups by `ItemClassName`, then all aggregations are computed in a single `Select`
- Cost of goods is calculated as `Quantity × CostPrice` per item, then summed
- Gross profit is computed as `TotalGrossSales - CostOfGoods`
- For databases with proper schema:  
  `SELECT i.ItemClassName, SUM(io.Quantity) AS TotalQuantity, SUM(io.Amount) AS TotalGrossSales, SUM(io.Quantity * i.CostPrice) AS CostOfGoods, SUM(io.Amount) - SUM(io.Quantity * i.CostPrice) AS GrossProfit FROM ItemOrders io JOIN Items i ON io.ItemId = i.Id WHERE io.IsRefunded = 0 GROUP BY i.ItemClassName`

**Result:**

| ClassName | TotalQuantity | TotalGrossSales | CostOfGoods | GrossProfit |
|-----------|---------------|-----------------|-------------|-------------|
| Food | 5 | 9600 | 3800 | 5800 |
| Drinks | 5 | 3600 | 1000 | 2600 |

---

## Exercise 5 — Multi-level Grouping

**Question:** Group `allItemOrders` first by `ItemClassName`, then within each class group by Item name. For each item show quantity sold and amount. Then compute a subtotal per class.

**Solution:**
```csharp
var salesByClassAndItem = allItemOrders
    .Where(io => !io.IsRefunded)
    .GroupBy(io => io.Item.ItemClassName)
    .Select(classGroup => new
    {
        ClassName = classGroup.Key,
        Items = classGroup
            .GroupBy(io => new { io.Item.Id, io.Item.Name })
            .Select(itemGroup => new
            {
                ItemName = itemGroup.Key.Name,
                QuantitySold = itemGroup.Sum(io => io.Quantity),
                TotalAmount = itemGroup.Sum(io => io.Amount)
            })
            .OrderByDescending(i => i.TotalAmount)
            .ToList(),
        ClassSubtotal = classGroup.Sum(io => io.Amount)
    })
    .OrderByDescending(c => c.ClassSubtotal)
    .ToList();
```

**Alternative (flattened result with Subtotal per row):**
```csharp
var flattenedResult = allItemOrders
    .Where(io => !io.IsRefunded)
    .GroupBy(io => new { io.Item.ItemClassName, io.Item.Name })
    .Select(g => new
    {
        ClassName = g.Key.ItemClassName,
        ItemName = g.Key.Name,
        QuantitySold = g.Sum(io => io.Quantity),
        TotalAmount = g.Sum(io => io.Amount)
    })
    .GroupBy(x => x.ClassName)
    .Select(classGroup => new
    {
        ClassName = classGroup.Key,
        Items = classGroup.Select(x => new
        {
            x.ItemName,
            x.QuantitySold,
            x.TotalAmount
        }).OrderByDescending(i => i.TotalAmount).ToList(),
        ClassSubtotal = classGroup.Sum(x => x.TotalAmount)
    })
    .OrderByDescending(c => c.ClassSubtotal)
    .ToList();
```

**Why this way:**
- First `GroupBy` groups by class, then a nested `GroupBy` within the `Select` groups by item
- Subtotals are computed at the class level using `Sum` on the class group
- The alternative flattens first then regroups, which can be more SQL-friendly
- For databases: This is best handled with a single query grouping by both ClassName and ItemName, then computing subtotals with a window function or a separate query

**Result (Hierarchical):**

| ClassName | Items (Name, Qty, Amount) | ClassSubtotal |
|-----------|---------------------------|---------------|
| Food | [(Peppered Chicken, 3, 6000), (Jollof Rice, 3, 3600)] | 9600 |
| Drinks | [(Heineken, 3, 2400), (Chapman, 2, 1200)] | 3600 |

---

## Exercise 6 — Void Report

**Question:** Get all voided orders. For each show Order ID, Staff who created it, Void reason, Total amount, and list of items on the order.

**Solution:**
```csharp
var voidedOrders = orders
    .Where(o => o.IsVoid)
    .Select(o => new
    {
        OrderId = o.Id,
        StaffName = $"{o.CreatedBy.FirstName} {o.CreatedBy.LastName}",
        o.VoidReason,
        o.TotalAmount,
        Items = o.Items
            .Where(io => !io.IsRefunded)
            .Select(io => new
            {
                ItemName = io.Item.Name,
                io.Quantity,
                io.Amount
            })
            .OrderBy(io => io.ItemName)
            .ToList()
    })
    .OrderBy(o => o.OrderId)
    .ToList();
```

**Why this way:**
- Filter for voided orders first (`Where(o => o.IsVoid)`)
- Project into a DTO with only needed fields
- Items are filtered (exclude refunded) and projected within the same query
- For databases with eager loading (`Include`):  
  `var voidedOrders = await _context.Orders.Include(o => o.Items).ThenInclude(io => io.Item).Where(o => o.IsVoid).AsNoTracking().ToListAsync();`  
  Then map in memory (items collection is already loaded)
- For best DB performance with projection: Use a split query or manually join to avoid cartesian explosion

**Result:**

| OrderId | StaffName | VoidReason | TotalAmount | Items (Name, Qty, Amount) |
|---------|-----------|------------|-------------|---------------------------|
| o3 | Alice Smith | Customer left | 2000 | [(Chapman, 1, 600), (Jollof Rice, 1, 1200)] |

---

## Exercise 7 — Revenue By Day Report

**Question:** Write a query that accepts dateFrom and dateTo, filters to paid/non-void orders, groups by date, and returns date, number of orders, and total revenue sorted by date.

**Solution:**
```csharp
DateTime dateFrom = new DateTime(2025, 1, 10);
DateTime dateTo = new DateTime(2025, 1, 11, 23, 59, 59);

var revenueByDay = orders
    .Where(o => o.IsPaid && !o.IsVoid)
    .Where(o => o.DateCreated >= dateFrom && o.DateCreated <= dateTo)
    .GroupBy(o => o.DateCreated.Date) // Group by just the date part
    .Select(g => new
    {
        Date = g.Key,
        OrderCount = g.Count(),
        TotalRevenue = g.Sum(o => o.TotalAmount)
    })
    .OrderBy(r => r.Date)
    .ToList();
```

**Alternative (for databases where `.Date` might not translate):**
```csharp
var revenueByDay = orders
    .Where(o => o.IsPaid && !o.IsVoid)
    .Where(o => o.DateCreated >= dateFrom && o.DateCreated <= dateTo)
    .GroupBy(o => new { o.DateCreated.Year, o.DateCreated.Month, o.DateCreated.Day })
    .Select(g => new
    {
        Date = new DateTime(g.Key.Year, g.Key.Month, g.Key.Day),
        OrderCount = g.Count(),
        TotalRevenue = g.Sum(o => o.TotalAmount)
    })
    .OrderBy(r => r.Date)
    .ToList();
```

**Why this way:**
- `GroupBy(o => o.DateCreated.Date)` groups by the date portion only (time is ignored)
- If using EF Core, `.Date` may not translate to SQL—use the alternative with Year/Month/Day or use `EntityFunctions.TruncateTime` (older EF) or `EF.Functions.DateDiffDay` patterns
- In modern EF Core, you can also use:  
  `.GroupBy(o => EF.Functions.DateTrunc("day", o.DateCreated))` (PostgreSQL) or  
  `.GroupBy(o => o.DateCreated.ToString("yyyy-MM-dd"))` (not ideal for indexing)
- Best for SQL Server: `GROUP BY CAST(DateCreated AS DATE)` — use `.GroupBy(o => o.DateCreated.Date)` and ensure your EF provider supports it

**Result:**

| Date | OrderCount | TotalRevenue |
|------|------------|--------------|
| 2025-01-10 | 2 | 9400 |
| 2025-01-11 | 1 | 2800 |

*(Note: Order o3 is voided, so it's excluded from the results)*

---

## Performance Tips for Database Scenarios (EF Core / LINQ-to-SQL)

1. **Filter Early, Project Late**: Apply `Where` before `Select` to reduce data before shaping
2. **Only Select What You Need**: Use `Select` to retrieve only required columns/properties
3. **Avoid N+1 Queries**: Use `Include` for related data or use projection with `Select` to join
4. **Use AsNoTracking**: For read-only queries, use `.AsNoTracking()` to skip change tracking overhead
5. **Beware of Client-Side Evaluation**: Some LINQ operations can't be translated to SQL (e.g., complex methods on entities). Check logs or use `.ToList()` before applying those operations
6. **Prefer Aggregates in Database**: Let the database do `Sum`, `Count`, `Average`—don't load all rows to compute in memory
7. **Index Your Columns**: Ensure columns used in `Where`, `Join`, `OrderBy`, and `GroupBy` have appropriate database indexes
8. **Use Async When Possible**: For web applications, use `ToListAsync()`, `FirstOrDefaultAsync()`, etc.
9. **Avoid Multiple Enumeration**: Materialize with `ToList()`/`ToListAsync()` if you need to enumerate multiple times
10. **Split Queries for Large Includes**: In EF Core 5+, use `.AsSplitQuery()` to avoid cartesian explosion when including multiple collections
