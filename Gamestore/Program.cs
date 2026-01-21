
using Gamestore.DTOs;
using Scalar.AspNetCore;

const string GetGameEndpointName = "GetGame";


var builder = WebApplication.CreateBuilder(args);

// 1. Register the .NET 9 native OpenAPI generator
builder.Services.AddOpenApi(); 


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Serves the JSON
    // This replaces SwaggerUI and works perfectly with .NET 9
    app.MapScalarApiReference(); 
}
app.MapGet("/",()=>"welcome to cj App");
// db
List<GameDto> games = [
    new(
        1,
        "Street Fighter II",
        "Fighting",
        19.99M,
        new DateOnly(1992,7,15)
    ),
    new(
        2,
        "Final Fantasy VII Rebirth",
        "RPG",
        69.99M,
        new DateOnly(2024,7,15)
    ),
    new(
        3,
        "Astro Ass",
        "Platformer",
        59.99M,
        new DateOnly(2024,9,15)
    ),
];


app.MapGet("/games", () => games);


app.MapGet("/games/{id}",(int id) =>
{
   var game= games.Find((game)=>game.Id==id);
    if (game == null)
    {
        return Results.NotFound();
    }
   return Results.Ok(game);
}).WithName(GetGameEndpointName);

app.MapPost("/games", (CreateGameDto newgame) =>
{
    GameDto game= new(
        games.Count+1,
        newgame.Name,
        newgame.Genre,
        newgame.Price,
        newgame.ReleaseDate
    );

    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName, new{id=game.Id},game);
});

app.MapPut("/games/{id}",(int id,UpdateGameDto updatedgame) =>
{
    // find index of games
    var index= games.FindIndex(game=>game.Id==id);
    if (index == -1)
    {
        return Results.BadRequest($"Game not found {id} ");
    }
    games[index]=new(
        id,
        updatedgame.Name,
        updatedgame.Genre,
        updatedgame.Price,
        updatedgame.ReleaseDate
    );
    return Results.NoContent();
});

app.MapDelete("/games/{id}",(int id) =>
{
    games.RemoveAll(game=>game.Id==id);
    return Results.NoContent();
});

// app run make sure you app is running on you server and listening for endpoints
app.Run();
