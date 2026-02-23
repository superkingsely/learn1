
# FoodEaseAPI Code Base Structure Diagram

---

## 🏗️ Solution Structure (.sln)

```
FoodEaseAPI/
├── FoodEase/                    # Main Web API Project (.NET 6)
├── FoodEase.Presentation/       # Controllers & Razor Views
├── Service/                     # Business Logic Layer
├── Service.Contracts/           # Service Interfaces
├── Repository/                  # Data Access Layer
├── Entities/                    # Domain Models & DTOs
├── Contracts/                  # Repository Interfaces
├── EmailViews/                  # Email Templates
└── LoggingService/              # Custom Logging
```

---

## 📁 Project Details

### 1. **FoodEase/** (Main API Project)
```
FoodEase/
├── FoodEase.sln               # Solution file
├── FoodEase.csproj            # Project file
├── Program.cs                 # Entry point (11,803 chars)
├── appsettings.json           # Configuration
├── appsettings.Development.json
├── Dockerfile
├── ContextFactory/            # EF Core DbContext factory
├── Extensions/                # DI, Auth, Swagger config
├── Migrations/                # EF Core migrations
├── Properties/
├── wwwroot/                   # Static files
└── Logs/                      # Application logs
```

### 2. **FoodEase.Presentation/** (Controllers)
```
FoodEase.Presentation/
├── FoodEase.Presentation.csproj
├── ApiResponseModel.cs
├── Controllers/               # API Endpoints (60+ controllers)
│   ├── OrderController.cs
│   ├── ItemController.cs
│   ├── ReportController.cs
│   ├── StaffController.cs
│   └── ...
└── RazorViews/               # HTML reports
```

### 3. **Service/** (Business Logic - 100+ services)
```
Service/
├── Service.csproj
├── ServiceManager.cs          # DI container
├── Automapper/                # Object mapping
│   └── RuntimeProfile.cs
├── [Core Services - 90+ files]
│   ├── OrderService.cs        # 333,735 chars (LARGEST)
│   ├── ItemService.cs         # 122,805 chars
│   ├── ItemStoreLocationService.cs
│   ├── PriceListService.cs    # 85,272 chars
│   ├── ReportService.cs       # 200,008 chars
│   ├── ReportServiceV2.cs     # 50,473 chars
│   ├── UserService.cs         # 75,158 chars
│   ├── StockTransferService.cs
│   ├── StockTransferReceiptService.cs
│   ├── InventoryShiftService.cs
│   ├── DiscountCodeService.cs
│   └── ...
└── [Real-time & Jobs]
    ├── OrderHub.cs            # SignalR hub
    ├── StockJobs.cs           # Hangfire jobs
    └── EmbedlyPayoutJobs.cs
```

### 4. **Service.Contracts/** (Service Interfaces)
```
Service.Contracts/
├── Service.Contracts.csproj
├── IServiceManager.cs
├── IOrderService.cs
├── IItemService.cs
├── IReportService.cs
├── IReportServiceV2.cs
├── IUserService.cs
├── IStaffService.cs
├── IRestaurantService.cs
├── IPaymentService.cs
├── IWhatsappService.cs
└── [60+ interface files]
    └── Views/
```

### 5. **Repository/** (Data Access Layer)
```
Repository/
├── Repository.csproj
├── RepositoryContext.cs       # DbContext (11,747 chars)
├── RepositoryBase.cs          # Generic base class
├── RepositoryManager.cs       # DI for all repos (38,621 chars)
└── ModelRepositories/         # 80+ repository implementations
    ├── OrderRepository.cs
    ├── ItemRepository.cs
    ├── ItemOrderRepository.cs
    ├── ShiftReportRepository.cs
    ├── StoreLocationRepository.cs
    └── ...
```

### 6. **Entities/** (Domain Models)
```
Entities/
├── Entities.csproj
├── DatabaseModels/             # 80+ Entity Classes
│   ├── DbEntity.cs            # Base entity (Id, IsActive, DateCreated)
│   ├── Restaurant.cs          # Root entity
│   ├── Order.cs               # Transaction entity
│   ├── Item.cs                # Menu item
│   ├── ItemOrder.cs           # Line item
│   ├── RevenueCenter.cs       # Checkout station
│   ├── Staff.cs               # Employee
│   ├── StoreLocation.cs       # Warehouse
│   ├── ShiftReport.cs         # Waste tracking
│   └── ...
├── DataTransferObjects/       # 100+ DTOs
│   ├── AddOrderDto.cs
│   ├── AddItemDto.cs
│   ├── ReportDto.cs
│   ├── ReportsGenDto.cs       # Report DTOs
│   ├── ReportsGenDtoV2.cs
│   └── ...
├── NonDbModels/               # Enums & helpers
│   ├── AuthCheck.cs
│   ├── Channels.cs
│   └── CustomRole.cs
└── Consts/
    ├── Currency.cs
    └── TimeZones.cs
```

### 7. **Contracts/** (Repository Interfaces)
```
Contracts/
├── Repository.Contracts.csproj
├── IRepositoryBase.cs         # Generic repository interface
├── IRepositoryManager.cs      # Main repository container
├── IOrderRepository.cs
├── IItemRepository.cs
├── IItemOrderRepository.cs
├── IRestaurantRepository.cs
├── IStaffRepository.cs
└── [100+ interface files]
```

### 8. **EmailViews/** (Razor Email Templates)
```
EmailViews/
├── EmailViews.csproj
├── order-email.cshtml
├── whatsapp-email.cshtml
└── stockimages/
```

### 9. **LoggingService/**
```
LoggingService/
├── LoggingService.csproj
├── LoggerManager.cs
└── LogManager.cs
```

---

## 🔗 Architecture Flow

```
┌─────────────────────────────────────────────────────────────┐
│                    API Request                               │
│            (e.g., POST /api/orders)                        │
└─────────────────────────┬───────────────────────────────────┘
                          │
                          ▼
┌─────────────────────────────────────────────────────────────┐
│              FoodEase.Presentation                          │
│                   Controllers                               │
│           (OrderController.cs, etc.)                      │
└─────────────────────────┬───────────────────────────────────┘
                          │
                          ▼
┌─────────────────────────────────────────────────────────────┐
│                    Service Layer                           │
│         ServiceManager → OrderService.cs                   │
│                    (Business Logic)                         │
└─────────────────────────┬───────────────────────────────────┘
                          │
                          ▼
┌─────────────────────────────────────────────────────────────┐
│                  Repository Layer                           │
│    RepositoryManager → OrderRepository → EF Core          │
└─────────────────────────┬───────────────────────────────────┘
                          │
                          ▼
┌─────────────────────────────────────────────────────────────┐
│                    PostgreSQL Database                       │
│    (Restaurant → Orders → ItemOrders → Items)              │
└─────────────────────────────────────────────────────────────┘
```

---

## 📊 Key Statistics

| Metric | Count |
|--------|-------|
| Projects | 7 |
| Controllers | 60+ |
| Services | 100+ |
| Entities | 80+ |
| DTOs | 100+ |
| Repository Interfaces | 100+ |
| Repository Implementations | 80+ |

---

## 🎯 Key Files by Size

| File | Size | Purpose |
|------|------|---------|
| `OrderService.cs` | 333KB | Order processing |
| `ItemService.cs` | 122KB | Menu management |
| `PriceListService.cs` | 85KB | Price management |
| `ReportService.cs` | 200KB | Reports |
| `RepositoryManager.cs` | 38KB | DI container |
| `ItemStoreLocationService.cs` | 49KB | Inventory |

This is a comprehensive **Restaurant POS (Point of Sale) System** built with clean architecture, repository pattern, and service layer.