using System;
using Gamestore.Frontend.Models;

namespace Gamestore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = new List<GameSummary>()
    {
         new(){
            Id=1,
            Name="free fire",
            Genre="Fighting",
            Price=19.99M,
            ReleaseDate= new DateOnly(2020,7,15)
        },
        new(){
            Id=2,
            Name="pes",
            Genre="Sports",
            Price=19.99M,
            ReleaseDate= new DateOnly(1992,7,15)
        },
        new(){
            Id=3,
            Name="cod",
            Genre="Fighting",
            Price=19.99M,
            ReleaseDate= new DateOnly(2022,7,15)
        },
   
    };
    // public GameStoreModel[] GetGames()=>[..games];
    //or
    public GameSummary[] GetGames()=>games.ToArray();

    private readonly GenreModel[] genres= new GenreClient().GetGenre();
    public void AddGames(GameDetails game)
    {
        GenreModel genre = GetGenreById(game.GenreId);
        var gamesummary = new GameSummary()
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate

        };
        games.Add(gamesummary);
    }

    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGamesummaryById(id);

        var genre = genres.Single(g => string.Equals(g.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate

        };

    }
    
    public void UpdateGame(GameDetails updatedgame)
    {
        var genre= GetGenreById(updatedgame.GenreId);
        var existinggame=GetGamesummaryById(updatedgame.Id);

        // dt
        existinggame.Id=updatedgame.Id;
        existinggame.Name=updatedgame.Name;
        existinggame.Genre=genre.Name;
        existinggame.Price=updatedgame.Price;
        existinggame.ReleaseDate=updatedgame.ReleaseDate;
    }
    public void DeleteGame(int id)
    {
        var game=GetGamesummaryById(id);
        games.Remove(game);
    }
    // helper method
    
    private GenreModel GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);
        var genre = genres.Single(g => g.Id == int.Parse(id));
        return genre;
    }

    private GameSummary GetGamesummaryById(int id)
    {
        GameSummary? game = games.Find(g => g.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }
}
