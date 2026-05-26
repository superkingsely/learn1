

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; }= string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UserType { get; set; }= "Regular";
    public List<RoleResponseDto> Roles { get; set; } = new List<RoleResponseDto>();
}