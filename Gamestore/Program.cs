
using Gamestore.Data;
using Gamestore.Endpoints;
using Gamestore.Models;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;



var builder = WebApplication.CreateBuilder(args);

// 1. Register the .NET 9 native OpenAPI generator
builder.Services.AddOpenApi(); 

// builder.Services.AddSqlite<GameStoreContext>(ConnString);

builder.AddGameStoreDb();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Serves the JSON
    // This replaces SwaggerUI and works perfectly with .NET 9
    app.MapScalarApiReference(); 
}
app.MapGet("/",()=>"welcome to cj App");

app.MapGamesEndpoints();
app.MigrateDb();
// app run make sure you app is running on you server and listening for endpoints
app.Run();
