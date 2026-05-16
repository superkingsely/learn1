using System;

namespace Linq.Entitiy;

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

