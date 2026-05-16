using System;
using Linq.Entitiy;

namespace Linq.Data;

public class Datadb
{

    public static List<Order> Gen()
    {
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
        return orders;
    }

}
