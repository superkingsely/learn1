using System;

namespace Linq.Entitiy;

public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Category { get; set; } // Family, Friend, Work, etc.
        public bool IsActive { get; set; }

        // Helper property for full name
        public string FullName => $"{FirstName} {LastName}";
    }


