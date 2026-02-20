
# Complete FoodEaseAPI Documentation
## A Comprehensive Guide for New Developers

---

# PART 1: API OVERVIEW

## What is FoodEaseAPI?
FoodEaseAPI is a **Restaurant POS (Point of Sale) Management System** built with .NET 6. It handles:
- Order Management
- Inventory & Stock Tracking
- Menu & Catalog Management  
- Staff & Customer Management
- Payment Processing
- Reports & Analytics
- Multi-channel integrations (WhatsApp, SMS, Email)

## Technology Stack
| Technology | Purpose |
|-----------|---------|
| .NET 6 | Framework |
| Entity Framework Core | ORM |
| PostgreSQL | Database |
| Hangfire | Background Jobs |
| SignalR | Real-time Updates |
| JWT Authentication | Security |
| Serilog | Logging |

---

# PART 2: PROJECT STRUCTURE

## Folder Organization
```
FoodEaseAPI/
├── Contracts/           # Repository interfaces (IRepositoryBase, IOrderRepository, etc.)
├── Entities/           # Database models and DTOs
│   ├── DatabaseModels/ # 80+ entity classes (Order, Item, Restaurant, etc.)
│   ├── DataTransferObjects/ # Request/Response objects
│   └── NonDbModels/   # Enums and helper classes
├── Repository/         # Repository implementations
├── Service/           # Business logic (100+ services)
├── Service.Contracts/ # Service interfaces
├── FoodEase/          # Main API project
│   ├── Controllers/   # API endpoints
│   ├── Extensions/    # Auth, Swagger config
│   └── ContextFactory/ # DB Context
├── EmailViews/        # Razor email templates
└── .github/           # CI/CD pipelines
```

---

# PART 3: CORE ENTITIES (The Source of Truth)

## Entity Hierarchy - Finding the Master Tables

### 1. RESTAURANT (Root Entity)
**File:** `Entities/DatabaseModels/Restaurant.cs`
**Purpose:** The top-level entity - represents each restaurant/business

**Key Fields:**
```csharp
public string Id { get; set; }          // Primary Key
public string Name { get; set; }
public string Code { get; set; }         // Restaurant code
public string RestaurantType { get; set; }  // Quick Service, Fine Dining, etc.
```

**Child Tables (depend on Restaurant):**
- ✅ RevenueCenters
- ✅ Staff  
- ✅ Customers
- ✅ Items
- ✅ Orders
- ✅ StoreLocations

**👉 NEW DEV TIP:** Every query MUST filter by RestaurantId (except auth endpoints)

---

### 2. REVENUE CENTER
**File:** `Entities/DatabaseModels/RevenueCenter.cs`
**Purpose:** A checkout station or table area within a restaurant
- "Main Bar", "Patio", "Takeout", "Delivery"

**Key Fields:**
```csharp
public string RestaurantId { get; set; }  // Foreign Key
public string Name { get; set; }           // e.g., "Bar", "Kitchen"
```

---

### 3. STAFF
**File:** `Entities/DatabaseModels/Staff.cs`
**Purpose:** Employees who create orders

**Key Fields:**
```csharp
public string RestaurantId { get; set; }  // Foreign Key
public string UserId { get; set; }        // Link to auth user
public string FirstName { get; set; }
public string LastName { get; set; }
public CustomRole Role { get; set; }       // Manager, Cashier, Waiter, etc.
```

---

### 4. ITEM (Menu Item)
**File:** `Entities/DatabaseModels/Item.cs`
**Purpose:** Menu items/foods sold

**Key Fields:**
```csharp
public string RestaurantId { get; set; }
public string Name { get; set; }
public decimal CostPrice { get; set; }      // Purchase price
public decimal SellingPrice { get; set; }  // Sale price

// Categorization
public string ItemClassId { get; set; }    // Category (Drinks, Food)
public string ItemGroup { get; set; }      // Single, Package, Recipe, Component
public ItemClass ItemClass { get; set; }

// Relationships
public List<ItemRevenueCenter> RevenueCenters { get; set; }  // Available at which centers
public List<ItemLocation> StoreLocations { get; set; }        // Stock locations
```

---

### 5. ORDER (Transaction)
**File:** `Entities/DatabaseModels/Order.cs`
**Purpose:** Represents a single transaction/table order

**Key Fields:**
```csharp
public string RestaurantId { get; set; }
public string RevenueCenterId { get; set; }    // Where order was placed
public string CreatedById { get; set; }        // Staff who created
public decimal TotalAmount { get; set; }
public bool IsPaid { get; set; }
public OrderStatus OrderStatus { get; set; }    // Pending, Processing, Completed, Void
public string SalesChannel { get; set; }       // Dine-in, Takeout, Delivery

// Related Entities
public List<ItemOrder> Items { get; set; }     // Line items
public List<OrderPaymentChannel> PaymentChannels { get; set; }
public List<OrderCharge> Charges { get; set; } // Service charges, taxes
```

---

### 6. ITEM ORDER (Line Item)
**File:** `Entities/DatabaseModels/Item.cs` (ItemOrder class)
**Purpose:** Individual item in an order

**Key Fields:**
```csharp
public string OrderId { get; set; }
public string ItemId { get; set; }
public decimal Amount { get; set; }       // Line total (price × qty)
public decimal Price { get; set; }       // Unit price
public double Quantity { get; set; }
public string ItemClassId { get; set; }  // For reporting
```

---

### 7. STORE LOCATION (Warehouse)
**File:** `Entities/DatabaseModels/StoreLocation.cs`
**Purpose:** Inventory storage locations

**Key Fields:**
```csharp
public string RestaurantId { get; set; }
public string Name { get; set; }           // "Main Warehouse", "Bar Store"
public bool IsActive { get; set; }
```

---

### 8. ITEM STORE LOCATION (Stock)
**File:** `Entities/DatabaseModels/ItemStoreLocation.cs`
**Purpose:** Tracks quantity of each item at each location

**Key Fields:**
```csharp
public string ItemId { get; set; }
public string StoreLocationId { get; set; }
public double AvailableQuantity { get; set; }
public double ThresholdQuantity { get; set; }  // Reorder alert level
```

---

## ENTITY RELATIONSHIPS DIAGRAM

```
RESTAURANT (Root)
    ├── REVENUE CENTERS (checkout points)
    │   └── TABLES
    ├── STAFF (employees)
    │   └── SESSIONS (work shifts)
    ├── CUSTOMERS
    ├── ITEMS (menu)
    │   ├── ITEM CLASS (category: Drinks, Food)
    │   ├── ITEM RECIPE (ingredients)
    │   ├── ITEM PACKAGE (combos)
    │   └── ITEM STORE LOCATION (stock)
    ├── ORDERS
    │   ├── ITEM ORDERS (line items)
    │   ├── ORDER PAYMENT CHANNELS
    │   ├── ORDER CHARGES (taxes, fees)
    │   └── REFUND LOGS
    ├── STORE LOCATIONS (warehouses)
    │   └── ITEM STORE LOCATIONS (stock qty)
    ├── VENDORS (suppliers)
    │   └── PURCHASE ORDERS
    └── DISCOUNT CODES
```

---

# PART 4: HOW TO FIND THE RIGHT CODE

## Step 1: Find the Entity
Go to `Entities/DatabaseModels/` and locate the relevant entity class.

**Example:** Need to work with Orders? → `Order.cs`

## Step 2: Find the Repository
Go to `Contracts/` and find the interface:
- `IOrderRepository.cs` for query methods

Implementation is in `Repository/ModelRepositories/OrderRepository.cs`

## Step 3: Find the Service
Go to `Service/`:
- Business logic: `OrderService.cs`
- Need specific feature? Check service names

## Step 4: Find the Controller
Go to `FoodEase.Presentation/Controllers/`:
- `OrderController.cs` - HTTP endpoints

---

# PART 5: COMMON DEVELOPMENT PATTERNS

## Pattern 1: Adding a New Filter to a Report

**Scenario:** Add StaffId filter to Sales by Individual Report

**Files to Modify:**

1. **DTO** - Add parameter to filter class
   - File: `Entities/DataTransferObjects/ReportDto.cs`
   - Add: `public string StaffId { get; set; }`

2. **Controller** - Pass parameter to service
   - File: `FoodEase.Presentation/Controllers/ReportController.cs`
   - Add: `model.StaffId` to service call

3. **Service Interface** - Define method signature
   - File: `Service.Contracts/IReportService.cs`
   - Add: `Task<...> GenerateReport(..., string staffId)`

4. **Service Implementation** - Add filter logic
   - File: `Service/ReportService.cs`
   - Add: `.Where(c => (string.IsNullOrEmpty(staffId) || c.CreatedById == staffId))`

5. **Repository** - Add query method (if needed)
   - File: `Repository/ModelRepositories/OrderRepository.cs`

---

## Pattern 2: Adding a New Field to Response

**Scenario:** Add ItemGroup to stock response

1. **DTO** - Add property
   - File: `Entities/DataTransferObjects/ItemStoreLocationDto.cs`

2. **AutoMapper** - Add mapping
   - File: `Service/Automapper/RuntimeProfile.cs`

---

## Pattern 3: Creating a New Endpoint

1. Create/Update Repository method
2. Create/Update Service method  
3. Create/Update Controller action
4. Test with Swagger

---

# PART 6: KEY CONCEPTS FOR NEW DEVELOPERS

## 1. Always Filter by RestaurantId
```csharp
// ✅ CORRECT
var orders = _repo.GetOrders()
    .Where(c => c.RestaurantId == restaurantId);

// ❌ WRONG - Returns all restaurants' data!
var orders = _repo.GetOrders();
```

## 2. Use String.IsNullOrEmpty for Optional Filters
```csharp
// Allows passing null or empty - returns all if not specified
.Where(c => (string.IsNullOrEmpty(staffId) || c.StaffId == staffId))
```

## 3. Always Check IsActive
```csharp
// Most entities have IsActive flag
.Where(c => c.IsActive == true)
```

## 4. Use DateTime.UtcNow for Timestamps
```csharp
public DateTime DateCreated { get; set; } = DateTime.UtcNow;
```

## 5. Navigation Properties Need .Include()
```csharp
// To access c.Order.Items in LINQ, must include
.Include(c => c.Items)
```

---

# PART 7: UNDERSTANDING REPORT DATA FLOW

## How Reports Get Data

### Example: Sales Mix Summary Report

```
1. Controller receives request
   ↓
2. Service calls Repository
   ↓
3. Repository queries Orders + ItemOrders + Items
   ↓
4. LINQ Groups by:
   - ItemClass (category)
   - Date
   - Item Name
   ↓
5. Calculates:
   - GrossSales = Sum(Amount)
   - QuantitySold = Sum(Quantity)
   - PercentageSales = (ItemSales / TotalSales) * 100
   ↓
6. AutoMapper converts to DTOs
   ↓
7. Returns JSON response
```

---

# PART 8: DEBUGGING TIPS

## Common Issues & Solutions

### 1. "Navigation property not loading"
**Cause:** Missing .Include()
**Fix:** Add `.Include(c => c.RelatedEntity)`

### 2. "Object reference not set to instance"
**Cause:** Nullable navigation property not loaded
**Fix:** Check if related entity exists before accessing

### 3. "No data returned"
**Cause:** 
- Filters too strict
- IsActive = false
- RestaurantId mismatch

**Fix:** Remove filters one by one to debug

### 4. "Decimal overflow" in reports
**Cause:** Large numbers × 100 exceeds decimal limit
**Fix:** Cast to double before calculation

---

# PART 9: QUICK REFERENCE

## Common Repository Methods

| Method | Purpose |
|--------|---------|
| `GetAll()` | Get all records |
| `GetById(id)` | Get single record |
| `GetOrders()` | Get orders with includes |
| `SalesByIndividualReport()` | Pre-built report query |

## Common Service Patterns

| Pattern | Example |
|---------|---------|
| Filter by restaurant | `c.RestaurantId == restaurantId` |
| Optional filter | `(string.IsNullOrEmpty(id) || c.Id == id)` |
| Date range | `c.DateCreated >= dateFrom && c.DateCreated <= dateTo` |
| Group by | `.GroupBy(c => c.Category)` |
| Sum/Aggregate | `.Sum(c => c.Amount)` |

---

# PART 10: FILES REFERENCE

## Key Files to Know

| File | Purpose |
|------|---------|
| `Restaurant.cs` | Root entity - every query starts here |
| `Order.cs` | Transaction entity |
| `Item.cs` | Menu item + Order line item |
| `ItemStoreLocation.cs` | Stock tracking |
| `ReportService.cs` | All report logic (200K+ lines) |
| `OrderService.cs` | Order processing (333K+ lines) |
| `ItemService.cs` | Menu management (122K+ lines) |

---

This documentation should help you navigate and contribute to FoodEaseAPI. Start by understanding the entity relationships, then look at existing implementations for patterns to follow.