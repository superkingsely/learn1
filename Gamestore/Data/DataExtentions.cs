using System;
using Gamestore.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Data;

// automatically update database 
// in app setting to reduce logging 
// loglevel add Microsoft.EntityFrameworkCore.Database.Command:"warning";
public static class DataExtentions
{
    public static void MigrateDb(this WebApplication app)
    {
    //    using var scope=app.Services.CreateScope();
        var scope=app.Services.CreateScope();
        var dbContext=scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }

    // seeding data
    public static void AddGameStoreDb(this WebApplicationBuilder builder)
    {
        var ConnString="Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(ConnString, optionsAction: Options => Options.UseSeeding((contex, _) =>
{
    if (!contex.Set<Genre>().Any())
    {
        contex.Set<Genre>().AddRange(
            new Genre {Name="fighting"},
            new Genre {Name="RPG"},
            new Genre {Name="riacing"},
            new Genre {Name="football"},
            new Genre {Name="Sport"}
        );

        contex.SaveChanges();
    }
}));
    }
}


// ✅ Option B (Recommended – Production-style)

// If you use migrations:

// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
//     db.Database.Migrate(); // 🔥 Triggers UseSeeding
// }