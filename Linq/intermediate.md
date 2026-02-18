# LINQ Intermediate Level Guide

A comprehensive guide to mastering intermediate LINQ concepts in C#.

---

## 📋 Table of Contents

1. [Advanced Filtering](#advanced-filtering)
2. [Projection Techniques](#projection-techniques)
3. [Joining Operations](#joining-operations)
4. [Grouping Operations](#grouping-operations)
5. [Sorting & Ordering](#sorting--ordering)
6. [Set Operations](#set-operations)
7. [Practice Exercises](#practice-exercises)

---

## Advanced Filtering

### Multiple Where() Conditions

You can chain multiple `Where()` clauses or combine conditions with AND (`&&`) or OR (`||`) operators.

```csharp
// Multiple Where() chaining
var result = contacts
    .Where(c => c.IsActive)
    .Where(c => c.Category == "Work");

// Single Where() with AND
var result2 = contacts
    .Where(c => c.IsActive && c.Category == "Work");

// Single Where() with OR
var result3 = contacts
    .Where(c => c.Category == "Work" || c.Category == "Family");
```

### Index-Based Filtering

The `Where()` overload with index allows filtering based on element position.

```csharp
var names = new[] { "Alice", "Bob", "Charlie", "David", "Eve" };

// Get elements at even positions (0, 2, 4)
var evenPositionNames = names.Where((name, index) => index % 2 == 0);
// Result: "Alice", "Charlie", "Eve"

// Get first 3 elements
var firstThree = names.Where((name, index) => index < 3);
```

### Exercise 2.1

**Task**: Get contacts whose names have more than 4 characters AND are active.

```csharp
// Your code here
var longNameActiveContacts = contacts
    .Where(c => c.FullName.Length > 4 && c.IsActive)
    .ToList();
```

---

## Projection Techniques

### Select() with Transformations

Transform each element into a new form.

```csharp
var numbers = new[] { 1, 2, 3, 4, 5 };

// Square each number
var squares = numbers.Select(n => n * n);
// Result: { 1, 4, 9, 16, 25 }

// Double and add 1
var transformed = numbers.Select(n => n * 2 + 1);
// Result: { 3, 5, 7, 9, 11 }
```

### Anonymous Type Projections

Create custom output shapes using anonymous types.

```csharp
var contacts = Context.InitializeContacts();

var summaries = contacts.Select(c => new
{
    Name = c.FullName,
    ContactInfo = $"{c.Email} | {c.Phone}",
    IsActive = c.IsActive ? "Yes" : "No"
});

foreach (var s in summaries)
{
    Console.WriteLine($"{s.Name} - {s.ContactInfo} ({s.IsActive})");
}
```

### Tuple Projections (C# 7+)

Use ValueTuples for cleaner projections.

```csharp
var pairs = numbers.Select(n => (Number: n, Square: n * n, Cube: n * n * n));

foreach (var (num, square, cube) in pairs)
{
    Console.WriteLine($"{num}^2 = {square}, {num}^3 = {cube}");
}
```

### SelectMany() for Flattening

Flatten nested collections into a single sequence.

```csharp
var teams = new[]
{
    new { TeamName = "A", Members = new[] { "Alice", "Bob" } },
    new { TeamName = "B", Members = new[] { "Charlie", "Diana" } }
};

// Flatten all members
var allMembers = teams.SelectMany(t => t.Members);
// Result: "Alice", "Bob", "Charlie", "Diana"

// With index
var withIndex = teams.SelectMany((t, i) => t.Members.Select(m => $"{i}: {m}"));
```

### Exercise 2.2

**Task**: Create a projection that returns each contact's name and a formatted string "Name works at Company".

```csharp
// Your code here
var workInfo = contacts
    .Select(c => $"{c.FullName} works at {c.Company}")
    .ToList();
```

---

## Joining Operations

### Join() - Inner Joins

Combine two sequences based on a matching key.

```csharp
// Sample data
var customers = new[]
{
    new { Id = 1, Name = "John" },
    new { Id = 2, Name = "Jane" },
    new { Id = 3, Name = "Bob" }
};

var orders = new[]
{
    new { CustomerId = 1, OrderTotal = 100 },
    new { CustomerId = 1, OrderTotal = 200 },
    new { CustomerId = 2, OrderTotal = 150 },
    new { CustomerId = 4, OrderTotal = 50 }  // No matching customer
};

// Inner join - only matching records
var joined = customers
    .Join(orders,
          c => c.Id,
          o => o.CustomerId,
          (c, o) => new { CustomerName = c.Name, OrderTotal = o.OrderTotal });

// Result: John-100, John-200, Jane-150
```

### GroupJoin() - Left Outer Joins

Group related items together, preserving all items from the left sequence.

```csharp
var grouped = customers
    .GroupJoin(orders,
               c => c.Id,
               o => o.CustomerId,
               (c, customerOrders) => new
               {
                   CustomerName = c.Name,
                   OrderCount = customerOrders.Count(),
                   TotalSpent = customerOrders.Sum(o => o.OrderTotal)
               });

// Result includes all customers, even without orders
```

### Multiple Join Conditions

Join on multiple keys using anonymous types.

```csharp
var products = new[]
{
    new { Category = "Electronics", Code = "E1", Name = "Laptop" },
    new { Category = "Food", Code = "F1", Name = "Apple" }
};

var sales = new[]
{
    new { Category = "Electronics", Code = "E1", Qty = 5 },
    new { Category = "Food", Code = "F1", Qty = 10 }
};

var multiJoin = products
    .Join(sales,
          p => new { p.Category, p.Code },
          s => new { s.Category, s.Code },
          (p, s) => new { p.Name, s.Qty });
```

### Exercise 2.3

**Task**: Join contacts with their categories to show "Name: Category".

```csharp
// Your code here
var categoryList = contacts
    .Select(c => new { Name = c.FullName, Category = c.Category });
```

---

## Grouping Operations

### GroupBy() Fundamentals

Group elements by a key.

```csharp
var contacts = Context.InitializeContacts();

// Group by category
var grouped = contacts.GroupBy(c => c.Category);

foreach (var group in grouped)
{
    Console.WriteLine($"Category: {group.Key}");
    foreach (var contact in group)
    {
        Console.WriteLine($"  - {contact.FullName}");
    }
}
```

### Working with Grouped Data

Aggregate data within groups.

```csharp
var categoryStats = contacts
    .GroupBy(c => c.Category)
    .Select(g => new
    {
        Category = g.Key,
        Count = g.Count(),
        ActiveCount = g.Count(c => c.IsActive),
        Companies = g.Select(c => c.Company).Distinct()
    });

foreach (var stat in categoryStats)
{
    Console.WriteLine($"{stat.Category}: {stat.Count} contacts, {stat.ActiveCount} active");
}
```

### ToLookup() vs GroupBy()

`ToLookup()` creates a lookup dictionary (immediate execution).

```csharp
// GroupBy - deferred, returns IEnumerable<IGrouping<TKey, TElement>>
var byCategory = contacts.GroupBy(c => c.Category);

// ToLookup - immediate, returns ILookup<TKey, TElement>
var lookup = contacts.ToLookup(c => c.Category);

// Can access directly by key
var workContacts = lookup["Work"];
```

### Composite Keys in Grouping

Group by multiple keys using anonymous types.

```csharp
var compositeGroup = contacts
    .GroupBy(c => new { c.Category, c.Company })
    .Select(g => new
    {
        Category = g.Key.Category,
        Company = g.Key.Company,
        Count = g.Count()
    });

foreach (var group in compositeGroup)
{
    Console.WriteLine($"{group.Category} - {group.Company}: {group.Count}");
}
```

### Exercise 2.4

**Task**: Group contacts by Company and show the count of contacts in each company.

```csharp
// Your code here
var byCompany = contacts
    .GroupBy(c => c.Company)
    .Select(g => new { Company = g.Key, Count = g.Count() });
```

---

## Sorting & Ordering

### OrderBy() and OrderByDescending()

Primary sorting operations.

```csharp
var contacts = Context.InitializeContacts();

// Sort by last name (A-Z)
var byLastName = contacts.OrderBy(c => c.LastName);

// Sort by last name (Z-A)
var byLastNameDesc = contacts.OrderByDescending(c => c.LastName);

// Sort by category then by first name
var multiSort = contacts
    .OrderBy(c => c.Category)
    .ThenBy(c => c.FirstName);
```

### ThenBy() and ThenByDescending()

Secondary sorting when primary key has same values.

```csharp
// Sort by Category (asc), then by Company (desc), then by FirstName (asc)
var complexSort = contacts
    .OrderBy(c => c.Category)
    .ThenByDescending(c => c.Company)
    .ThenBy(c => c.FirstName);
```

### Reverse() Operation

Reverse the order of elements.

```csharp
var numbers = new[] { 1, 2, 3, 4, 5 };
var reversed = numbers.Reverse();
// Result: { 5, 4, 3, 2, 1 }

// Reverse sorted result
var reversedSort = contacts.OrderBy(c => c.Name).Reverse();
```

### Custom Comparers in Sorting

Use `IComparer<T>` for custom sorting logic.

```csharp
public class LengthComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return x.Length.CompareTo(y.Length);
    }
}

var names = new[] { "Alice", "Bob", "Charlie", "David" };
var sortedByLength = names.OrderBy(n => n, new LengthComparer());
// Result: "Bob", "Alice", "David", "Charlie"
```

### Exercise 2.5

**Task**: Sort contacts by IsActive (active first), then by Company name.

```csharp
// Your code here
var sortedContacts = contacts
    .OrderByDescending(c => c.IsActive)
    .ThenBy(c => c.Company);
```

---

## Set Operations

### Distinct() - Removing Duplicates

Get unique elements from a sequence.

```csharp
var numbers = new[] { 1, 2, 2, 3, 3, 3, 4, 5 };
var unique = numbers.Distinct();
// Result: { 1, 2, 3, 4, 5 }

// Distinct by custom key
var contacts = Context.InitializeContacts();
var categories = contacts.Select(c => c.Category).Distinct();
```

### Union(), Intersect(), Except()

Set operations on collections.

```csharp
var setA = new[] { 1, 2, 3, 4 };
var setB = new[] { 3, 4, 5, 6 };

// Union - all unique elements from both
var union = setA.Union(setB);
// Result: { 1, 2, 3, 4, 5, 6 }

// Intersect - common elements
var intersect = setA.Intersect(setB);
// Result: { 3, 4 }

// Except - elements in A but not in B
var except = setA.Except(setB);
// Result: { 1, 2 }
```

### Concat() Operations

Concatenate sequences without removing duplicates.

```csharp
var first = new[] { 1, 2, 3 };
var second = new[] { 3, 4, 5 };

var concatenated = first.Concat(second);
// Result: { 1, 2, 3, 3, 4, 5 }

// To remove duplicates after concat
var uniqueConcat = first.Concat(second).Distinct();
```

### Exercise 2.6

**Task**: Get all unique categories from contacts and all unique companies, then find their intersection.

```csharp
// Your code here
var categories = contacts.Select(c => c.Category).Distinct();
var companies = contacts.Select(c => c.Company).Distinct();
var common = categories.Intersect(companies);
```

---

## Practice Exercises

### Exercise 1: Advanced Filtering
Get contacts at even indices (0, 2, 4...) who are active.

```csharp
var result = contacts
    .Where((c, index) => index % 2 == 0 && c.IsActive)
    .ToList();
```

### Exercise 2: Complex Projection
Create a list of contact cards with format: "[Name] - [Company] ([Category])"

```csharp
var cards = contacts
    .Select(c => $"{c.FullName} - {c.Company} ({c.Category})")
    .ToList();
```

### Exercise 3: Grouping with Aggregation
Show each company with count of active and inactive contacts.

```csharp
var companyStats = contacts
    .GroupBy(c => c.Company)
    .Select(g => new
    {
        Company = g.Key,
        Active = g.Count(c => c.IsActive),
        Inactive = g.Count(c => !c.IsActive)
    });
```

### Exercise 4: Multi-Level Sorting
Sort by Category (desc), then by IsActive (active first), then by Name.

```csharp
var sorted = contacts
    .OrderByDescending(c => c.Category)
    .ThenByDescending(c => c.IsActive)
    .ThenBy(c => c.FullName);
```

### Exercise 5: Set Operations
Find contacts that appear in both "Work" and "Family" categories.

```csharp
var workContacts = contacts.Where(c => c.Category == "Work").Select(c => c.FullName);
var familyContacts = contacts.Where(c => c.Category == "Family").Select(c => c.FullName);
var both = workContacts.Intersect(familyContacts);
```

---

## ✅ Summary

You now understand:

- ✅ Multiple `Where()` conditions and index-based filtering
- ✅ `Select()` transformations and `SelectMany()` flattening
- ✅ `Join()` and `GroupJoin()` operations
- ✅ `GroupBy()` and `ToLookup()` grouping
- ✅ `OrderBy()`, `ThenBy()`, and custom sorting
- ✅ `Distinct()`, `Union()`, `Intersect()`, `Except()`

---

## 📚 Next Steps

Continue to the Advanced Level to learn:
- Deferred vs Immediate Execution
- Element Operators
- Aggregation Operators
- Parallel LINQ (PLINQ)
- Expression Trees

---

**Happy Coding! 🚀**
