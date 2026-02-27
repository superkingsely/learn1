using System;

namespace MODELS.Models.InputModel;

public class ApplicationUserLoginInputModel
{
        
        public required string Email { get; set; }

        public required string Password { get; set; }
}
