# LINQ Practice Exercises - Restaurant Report Service

## Practice Dataset

Here's a self-contained C# dataset modeled closely after the ReportService class. You can paste this into a console app or .NET Fiddle and experiment:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

// ---- MODELS ----

public class Restaurant { public string Id { get; set; } public string Name { get; set; } }
public class RevenueCenter { public string Id { get; set; } public string Name { get; set; } }
public class Staff { public string Id { get; set; } public string FirstName { get; set; } public string LastName { get; set; } }
public class Item { public string Id { get; set; } public string Name { get; set; } public string ItemClassName { get; set; } public decimal CostPrice { get; set; } public decimal SellingPrice { get; set; } }

public class ItemOrder
{
    public string Id { get; set; }
    public string OrderId { get; set; }
    public Item Item { get; set; }
    public double Quantity { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsRefunded { get; set; }
    public bool IsActive { get; set; }
}

public class Order
{
    public string Id { get; set; }
    public string RestaurantId { get; set; }
    public string RevenueCenterId { get; set; }
    public RevenueCenter RevenueCenter { get; set; }
    public Staff CreatedBy { get; set; }
    public decimal TotalAmount { get; set; }
    public int GuestCount { get; set; }
    public bool IsPaid { get; set; }
    public bool IsVoid { get; set; }
    public bool IsDiscounted { get; set; }
    public decimal DiscountAmount { get; set; }
    public bool HasRefunds { get; set; }
    public bool HasBeenRefunded { get; set; }
    public DateTime DateCreated { get; set; }
    public List<ItemOrder> Items { get; set; } = new();
    public string VoidReason { get; set; }
}

// ---- SEED DATA ----

var restaurant = new Restaurant { Id = "r1", Name = "The Grand Bistro" };

var rc1 = new RevenueCenter { Id = "rc1", Name = "Main Hall" };
var rc2 = new RevenueCenter { Id = "rc2", Name = "Rooftop Bar" };

var staff1 = new Staff { Id = "s1", FirstName = "Alice", LastName = "Smith" };
var staff2 = new Staff { Id = "s2", FirstName = "Bob", LastName = "Jones" };

var item1 = new Item { Id = "i1", Name = "Jollof Rice", ItemClassName = "Food", CostPrice = 500, SellingPrice = 1200 };
var item2 = new Item { Id = "i2", Name = "Peppered Chicken", ItemClassName = "Food", CostPrice = 800, SellingPrice = 2000 };
var item3 = new Item { Id = "i3", Name = "Chapman", ItemClassName = "Drinks", CostPrice = 200, SellingPrice = 600 };
var item4 = new Item { Id = "i4", Name = "Heineken", ItemClassName = "Drinks", CostPrice = 300, SellingPrice = 800 };

var orders = new List<Order>
{
    new Order {
        Id = "o1", RestaurantId = "r1", RevenueCenterId = "rc1", RevenueCenter = rc1,
        CreatedBy = staff1, TotalAmount = 3800, GuestCount = 2,
        IsPaid = true, IsVoid = false, IsDiscounted = false,
        DateCreated = new DateTime(2025, 1, 10, 12, 0, 0),
        Items = new List<ItemOrder> {
            new ItemOrder { Id = "io1", OrderId = "o1", Item = item1, Quantity = 2, Amount = 2400, DateCreated = new DateTime(2025,1,10), IsRefunded = false, IsActive = true },
            new ItemOrder { Id = "io2", OrderId = "o1", Item = item3, Quantity = 2, Amount = 1200, DateCreated = new DateTime(2025,1,10), IsRefunded = false, IsActive = true }
        }
    },
    new Order {
        Id = "o2", RestaurantId = "r1", RevenueCenterId = "rc2", RevenueCenter = rc2,
        CreatedBy = staff2, TotalAmount = 5600, GuestCount = 3,
        IsPaid = true, IsVoid = false, IsDiscounted = true, DiscountAmount = 400,
        DateCreated = new DateTime(2025, 1, 10, 19, 0, 0),
        Items = new List<ItemOrder> {
            new ItemOrder { Id = "io3", OrderId = "o2", Item = item2, Quantity = 2, Amount = 4000, DateCreated = new DateTime(2025,1,10), IsRefunded = false, IsActive = true },
            new ItemOrder { Id = "io4", OrderId = "o2", Item = item4, Quantity = 2, Amount = 1600, DateCreated = new DateTime(2025,1,10), IsRefunded = false, IsActive = true }
        }
    },
    new Order {
        Id = "o3", RestaurantId = "r1", RevenueCenterId = "rc1", RevenueCenter = rc1,
        CreatedBy = staff1, TotalAmount = 2000, GuestCount = 1,
        IsPaid = true, IsVoid = true, IsDiscounted = false, VoidReason = "Customer left",
        DateCreated = new DateTime(2025, 1, 11, 14, 0, 0),
        Items = new List<ItemOrder> {
            new ItemOrder { Id = "io5", OrderId = "o3", Item = item1, Quantity = 1, Amount = 1200, DateCreated = new DateTime(2025,1,11), IsRefunded = false, IsActive = true },
            new ItemOrder { Id = "io6", OrderId = "o3", Item = item3, Quantity = 1, Amount = 600, DateCreated = new DateTime(2025,1,11), IsRefunded = false, IsActive = true }
        }
    },
    new Order {
        Id = "o4", RestaurantId = "r1", RevenueCenterId = "rc2", RevenueCenter = rc2,
        CreatedBy = staff2, TotalAmount = 2800, GuestCount = 2,
        IsPaid = true, IsVoid = false, IsDiscounted = false,
        DateCreated = new DateTime(2025, 1, 11, 20, 0, 0),
        Items = new List<ItemOrder> {
            new ItemOrder { Id = "io7", OrderId = "o4", Item = item2, Quantity = 1, Amount = 2000, DateCreated = new DateTime(2025,1,11), IsRefunded = false, IsActive = true },
            new ItemOrder { Id = "io8", OrderId = "o4", Item = item4, Quantity = 1, Amount = 800, DateCreated = new DateTime(2025,1,11), IsRefunded = false, IsActive = true }
        }
    }
};

var allItemOrders = orders.SelectMany(o => o.Items).ToList();
```

---

## Exercise 1 — Basic Filter
**Like `GenerateSalesByIndividualReport`**

Get all paid, non-void orders from "rc1" (Main Hall) between Jan 10 and Jan 11 2025.

**Expected output fields:** Staff name, TotalAmount, DateCreated

---

## Exercise 2 — Aggregation
**Like `OperationReport`**

From all paid orders, calculate:
- Total revenue (sum of TotalAmount)
- Total guest count
- Average spend per order
- How many were discounted

---

## Exercise 3 — GroupBy Staff
**Like `StaffSalesReport`**

Group paid orders by staff member. For each staff, show:
- Staff full name
- Number of orders
- Total sales amount

---

## Exercise 4 — GroupBy Item Class
**Like `DailySalesByItemReport`**

From `allItemOrders`, group by `Item.ItemClassName`. For each class show:
- Class name
- Total quantity sold
- Total gross sales
- Cost of goods (quantity × CostPrice per item)
- Gross profit (gross sales - cost of goods)

---

## Exercise 5 — Multi-level Grouping
**Like `SalesByItemReport`**

Group `allItemOrders` first by `ItemClassName`, then within each class group by Item name. For each item show quantity sold and amount. Then compute a subtotal per class.

---

## Exercise 6 — Void Report
**Like `VoidReasonReport`**

Get all voided orders. For each show:
- Order ID
- Staff who created it
- Void reason
- Total amount
- List of items on the order

---

## Exercise 7 — Revenue By Day Report
**Putting it all together**

Write a query that:
- Accepts a dateFrom and dateTo
- Filters to paid, non-void orders only
- Groups orders by DATE (just the date, not time)
- For each date returns: date, number of orders, total revenue
- Returns results sorted by date

---

## Key LINQ Operations Reference

| Operation | Purpose | Example |
|-----------|---------|---------|
| `Where` | Filter rows | `.Where(o => o.IsPaid)` |
| `Select` | Project/shape data | `.Select(o => new { o.Id, o.TotalAmount })` |
| `GroupBy` | Group by key | `.GroupBy(o => o.CreatedBy.FirstName)` |
| `OrderBy` / `OrderByDescending` | Sort | `.OrderBy(o => o.DateCreated)` |
| `Sum` | Aggregate sum | `.Sum(o => o.TotalAmount)` |
| `Count` | Count items | `.Count()` |
| `Any` | Check if any match | `.Any(o => o.IsDiscounted)` |
| `SelectMany` | Flatten nested collections | `orders.SelectMany(o => o.Items)` |
| `ToList` | Execute query | `.ToList()` |
