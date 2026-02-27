using System;
using MODELS.Enum;

namespace MODELS.Models.InputModel;

public class ApplicationUserRegisterInputModel
{
        
        public Gender? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ImageName { get; set; }

        
        public required string Email { get; set; }

        
        public required string Password { get; set; }

        
        public required string ConfirmPassword { get; set; }
}
