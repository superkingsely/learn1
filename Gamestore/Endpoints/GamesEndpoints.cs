using System;
using Gamestore.DTOs;

namespace Gamestore.Endpoints;


// contains extenstion methods
public static class GamesEndpoints
{
const string GetGameEndpointName = "GetGame";

    // db
 private static readonly List<GameDto> games = [
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

public static void MapGamesEndpoints( this WebApplication app )
    {
        var group=app.MapGroup("/games");
       
        group.MapGet("/", () => games);

        group.MapGet("/{id}",(int id) =>
{
   var game= games.Find((game)=>game.Id==id);
    if (game == null)
    {
        return Results.NotFound();
    }
   return Results.Ok(game);
}).WithName(GetGameEndpointName);

        group.MapPost("/", (CreateGameDto newgame) =>
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

        group.MapPut("/{id}",(int id,UpdateGameDto updatedgame) =>
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

        group.MapDelete("/{id}",(int id) =>
{
    games.RemoveAll(game=>game.Id==id);
    return Results.NoContent();
});

    }

}
