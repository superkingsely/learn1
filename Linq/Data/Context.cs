using System;
// using System.Collections.Generic;
using Linq.Entitiy;

namespace Linq.Data;

public static class Context
{
    public static List<Contact> InitializeContacts()
        {
            return new List<Contact>
            {
                new Contact { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@email.com", Phone = "555-1234", Company = "TechCorp", Category = "Work", IsActive = true },
                new Contact { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@email.com", Phone = "555-5678", Company = "DesignStudio", Category = "Work", IsActive = true },
                new Contact { Id = 3, FirstName = "Bob", LastName = "Johnson", Email = "bob@email.com", Phone = "555-9012", Company = "", Category = "Family", IsActive = true },
                new Contact { Id = 4, FirstName = "Alice", LastName = "Williams", Email = "alice@email.com", Phone = "555-3456", Company = "TechCorp", Category = "Work", IsActive = false },
                new Contact { Id = 5, FirstName = "Charlie", LastName = "Brown", Email = "charlie@email.com", Phone = "555-7890", Company = "", Category = "Friend", IsActive = true },
                new Contact { Id = 6, FirstName = "Diana", LastName = "Miller", Email = "diana@email.com", Phone = "555-2345", Company = "StartupXYZ", Category = "Work", IsActive = true },
                new Contact { Id = 7, FirstName = "Eve", LastName = "Davis", Email = "eve@email.com", Phone = "555-6789", Company = "TechCorp", Category = "Friend", IsActive = true },
                new Contact { Id = 8, FirstName = "Frank", LastName = "Garcia", Email = "frank@email.com", Phone = "555-0123", Company = "", Category = "Family", IsActive = true },
                new Contact { Id = 9, FirstName = "Grace", LastName = "Martinez", Email = "grace@email.com", Phone = "555-4567", Company = "DesignStudio", Category = "Work", IsActive = false },
                new Contact { Id = 10, FirstName = "Henry", LastName = "Anderson", Email = "henry@email.com", Phone = "555-8901", Company = "StartupXYZ", Category = "Friend", IsActive = true }
            };
        }

}
