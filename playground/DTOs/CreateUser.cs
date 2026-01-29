namespace playground.DTOs;

public record class CreateUser
{
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Class { get; init; } = string.Empty;
}
