using System;
using MODELS.Enum;

namespace MODELS;

public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public short? VerificationCode { get; set; }
    public string? ImageName { get; set; }
    public bool? Activity { get; set; }
    public string? FullName => $"{FirstName} {LastName}";
}
