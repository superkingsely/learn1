using System;
using System.ComponentModel.DataAnnotations;

namespace Gamestore.Frontend.Models;

public class GameDetails
{
    public int Id {get;set;}
    [Required(ErrorMessage ="pls game name required thank u")]//okay i hv to restart watch server
    public  string? Name{get;set;}
    // public required string Name{get;set;}
    [Required]
    public string? GenreId{get;set;}
    public decimal Price{get;set;}
    public DateOnly ReleaseDate{get;set;}=DateOnly.FromDateTime(DateTime.UtcNow);
}
