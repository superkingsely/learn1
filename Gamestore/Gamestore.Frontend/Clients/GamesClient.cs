using System;
using Gamestore.Frontend.Models;

namespace Gamestore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameStoreModel> games = new List<GameStoreModel>()
    {
         new(){
            Id=1,
            Name="free fire",
            Genre="first shooter",
            Price=19.99M,
            ReleaseDate= new DateOnly(2020,7,15)
        },
        new(){
            Id=2,
            Name="pes",
            Genre="football",
            Price=19.99M,
            ReleaseDate= new DateOnly(1992,7,15)
        },
        new(){
            Id=3,
            Name="cod",
            Genre="first shooter",
            Price=19.99M,
            ReleaseDate= new DateOnly(2022,7,15)
        },
   
    };
    public GameStoreModel[] GetGames()=>games.ToArray();
}
