using System.ComponentModel.DataAnnotations;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; }= string.Empty;
    public string PasswordHash { get; set; }=   string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string UserType { get; set; }= "Regular";
    public List<Role> Roles { get; set; } = new List<Role>();
}

