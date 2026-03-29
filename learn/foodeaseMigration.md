`-p` = `--project` and `-s` = `--startup-project`

Here are the full commands with no shortcuts:

### Step 1 — Add Migration
```bash
dotnet ef migrations add RevenueLineTable --project FoodEase/FoodEase.csproj --startup-project FoodEase/FoodEase.csproj
```

### Step 2 — Apply to Database
```bash
dotnet ef database update --project FoodEase/FoodEase.csproj --startup-project FoodEase/FoodEase.csproj
```
if you are currently on the foodease folder then d cmd becomes
dotnet ef database update --project FoodEase.csproj --startup-project FoodEase.csproj
---

### What Each Flag Means

| Short | Full | Meaning |
|---|---|---|
| `-p` | `--project` | The project that contains `RepositoryContext.cs` and your `Migrations/` folder |
| `-s` | `--startup-project` | The project that contains `Program.cs` and `appsettings.json` — used to find your connection string |

In your case both point to the same `.csproj` because `FoodEase` is your **monolith entry point** that references everything else, so EF can find both the context and the connection string from one place.