using System;
using Gamestore.Frontend.Models;

namespace Gamestore.Frontend.Clients;

public class GenreClient
{
    private readonly GenreModel[] genres= [
        new(){
            Id=1,
            Name="Fighting"
        },
        new(){
            Id=2,
            Name="Roleplaying"
        },
        new(){
            Id=3,
            Name="Sports"
        },
        new(){
            Id=4,
            Name="Racing"
        },
        new(){
            Id=5,
            Name="Kids and family"
        }
    ];

    public GenreModel[] GetGenre()=>genres;
}
