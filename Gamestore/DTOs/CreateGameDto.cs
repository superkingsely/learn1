using System.ComponentModel.DataAnnotations;

namespace Gamestore.DTOs;

public record class CreateGameDto(
   [Required] string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
