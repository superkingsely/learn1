using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    // Contact class representing a contact in the list
    class Contact
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║         LINQ Contact List Manager - Beginner Project      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Initialize sample contacts
            List<Contact> contacts = InitializeContacts();

            // Display all contacts
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("ALL CONTACTS");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            DisplayContacts(contacts);

            // ═══════════════════════════════════════════════════════
            // BEGINNER LINQ CONCEPTS DEMONSTRATION
            // ═══════════════════════════════════════════════════════

            // 1. FILTERING WITH WHERE()
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("1. FILTERING WITH WHERE()");
            Console.WriteLine("═══════════════════════════════════════════════════════════");

            // Example 1.1: Get all active contacts
            Console.WriteLine("\n--- Active Contacts ---");
            var activeContacts = contacts.Where(c => c.IsActive).ToList();
            DisplayContacts(activeContacts);

            // Example 1.2: Get contacts from a specific company
            Console.WriteLine("\n--- Contacts from TechCorp ---");
            var techCorpContacts = contacts.Where(c => c.Company == "TechCorp").ToList();
            DisplayContacts(techCorpContacts);

            // Example 1.3: Get contacts with multiple conditions
            Console.WriteLine("\n--- Active Contacts from Work Category ---");
            var activeWorkContacts = contacts
                .Where(c => c.IsActive && c.Category == "Work")
                .ToList();
            DisplayContacts(activeWorkContacts);

            // Example 1.4: Filter by phone number pattern
            Console.WriteLine("\n--- Contacts with Phone Starting with '555' ---");
            var phoneStartsWith555 = contacts.Where(c => c.Phone.StartsWith("555")).ToList();
            DisplayContacts(phoneStartsWith555);

            // 2. PROJECTION WITH SELECT()
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("2. PROJECTION WITH SELECT()");
            Console.WriteLine("═══════════════════════════════════════════════════════════");

            // Example 2.1: Select full names
            Console.WriteLine("\n--- Full Names of All Contacts ---");
            var fullNames = contacts.Select(c => c.FullName);
            foreach (var name in fullNames)
            {
                Console.WriteLine($"  {name}");
            }

            // Example 2.2: Project to anonymous type (contact summary)
            Console.WriteLine("\n--- Contact Summaries (Name & Email) ---");
            var summaries = contacts.Select(c => new
            {
                Name = c.FullName,
                Email = c.Email
            });
            foreach (var summary in summaries)
            {
                Console.WriteLine($"  {summary.Name}: {summary.Email}");
            }

            // Example 2.3: Project with transformation
            Console.WriteLine("\n--- Contact Info with Index ---");
            var numberedContacts = contacts
                .Select((c, index) => new { Index = index + 1, Name = c.FullName, Company = c.Company });
            foreach (var contact in numberedContacts)
            {
                Console.WriteLine($"  #{contact.Index}: {contact.Name} - {contact.Company}");
            }

            // Example 2.4: Select with string transformation
            Console.WriteLine("\n--- Email Domains ---");
            var emailDomains = contacts
                .Select(c => new { Name = c.FullName, Domain = c.Email.Split('@')[1] });
            foreach (var item in emailDomains)
            {
                Console.WriteLine($"  {item.Name}: @{item.Domain}");
            }

            // 3. SORTING WITH ORDERBY() / THENBY()
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("3. SORTING WITH ORDERBY() / THENBY()");
            Console.WriteLine("═══════════════════════════════════════════════════════════");

            // Example 3.1: Sort by last name
            Console.WriteLine("\n--- Contacts Sorted by Last Name ---");
            var sortedByLastName = contacts.OrderBy(c => c.LastName).ToList();
            DisplayContacts(sortedByLastName);

            // Example 3.2: Sort by category, then by first name
            Console.WriteLine("\n--- Contacts Sorted by Category, Then by First Name ---");
            var sortedByCategoryThenName = contacts
                .OrderBy(c => c.Category)
                .ThenBy(c => c.FirstName)
                .ToList();
            DisplayContacts(sortedByCategoryThenName);

            // Example 3.3: Sort by company (descending), then by last name
            Console.WriteLine("\n--- Contacts Sorted by Company (Desc), Then by Last Name ---");
            var sortedByCompanyDesc = contacts
                .OrderByDescending(c => c.Company)
                .ThenBy(c => c.LastName)
                .ToList();
            DisplayContacts(sortedByCompanyDesc);

            // 4. AGGREGATION OPERATIONS
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("4. AGGREGATION OPERATIONS");
            Console.WriteLine("═══════════════════════════════════════════════════════════");

            // Example 4.1: Count total contacts
            Console.WriteLine($"\n--- Total Contacts: {contacts.Count()} ---");

            // Example 4.2: Count active contacts
            var activeCount = contacts.Count(c => c.IsActive);
            Console.WriteLine($"--- Active Contacts: {activeCount} ---");

            // Example 4.3: Count contacts by category
            Console.WriteLine("\n--- Contact Count by Category ---");
            var contactsByCategory = contacts
                .GroupBy(c => c.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .OrderBy(g => g.Category);
            foreach (var group in contactsByCategory)
            {
                Console.WriteLine($"  {group.Category}: {group.Count}");
            }

            // Example 4.4: Count contacts by company
            Console.WriteLine("\n--- Contact Count by Company ---");
            var contactsByCompany = contacts
                .GroupBy(c => c.Company == "" ? "Individual" : c.Company)
                .Select(g => new { Company = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count);
            foreach (var group in contactsByCompany)
            {
                Console.WriteLine($"  {group.Company}: {group.Count}");
            }

            // 5. DISTINCT OPERATIONS
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("5. DISTINCT OPERATIONS");
            Console.WriteLine("═══════════════════════════════════════════════════════════");

            // Example 5.1: Get distinct categories
            Console.WriteLine("\n--- Distinct Categories ---");
            var categories = contacts.Select(c => c.Category).Distinct();
            foreach (var category in categories)
            {
                Console.WriteLine($"  {category}");
            }

            // Example 5.2: Get distinct companies (non-empty)
            Console.WriteLine("\n--- Distinct Companies (with contacts) ---");
            var companies = contacts
                .Where(c => c.Company != "")
                .Select(c => c.Company)
                .Distinct();
            foreach (var company in companies)
            {
                Console.WriteLine($"  {company}");
            }

            // 6. FIRST/SINGLE OPERATORS
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("6. FIRST/SINGLE OPERATORS");
            Console.WriteLine("═══════════════════════════════════════════════════════════");

            // Example 6.1: First contact in the list
            Console.WriteLine("\n--- First Contact (Ordered by ID) ---");
            var firstContact = contacts.OrderBy(c => c.Id).First();
            Console.WriteLine($"  {firstContact.FullName} - {firstContact.Email}");

            // Example 6.2: FirstOrDefault (safe retrieval)
            Console.WriteLine("\n--- First Contact Matching 'John' ---");
            var johnContact = contacts.FirstOrDefault(c => c.FirstName == "John");
            if (johnContact != null)
            {
                Console.WriteLine($"  Found: {johnContact.FullName}");
            }
            else
            {
                Console.WriteLine("  Not found");
            }

            // Example 6.3: Find a specific contact by email
            Console.WriteLine("\n--- Contact by Email ---");
            var contactByEmail = contacts.FirstOrDefault(c => c.Email == "jane@email.com");
            if (contactByEmail != null)
            {
                Console.WriteLine($"  Found: {contactByEmail.FullName} - {contactByEmail.Phone}");
            }

            // 7. PRACTICAL SEARCH FUNCTIONALITY
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("7. PRACTICAL SEARCH FUNCTIONALITY");
            Console.WriteLine("═══════════════════════════════════════════════════════════");

            // Example 7.1: Search by name (partial match)
            Console.WriteLine("\n--- Search for 'Alice' ---");
            var searchResults = contacts
                .Where(c => c.FirstName.Contains("Alice") || c.LastName.Contains("Alice"))
                .ToList();
            DisplayContacts(searchResults);

            // Example 7.2: Get contacts with company name containing "Tech"
            Console.WriteLine("\n--- Companies Containing 'Tech' ---");
            var techCompanies = contacts
                .Where(c => c.Company.Contains("Tech"))
                .Select(c => new { c.FullName, c.Company, c.Email })
                .ToList();
            foreach (var contact in techCompanies)
            {
                Console.WriteLine($"  {contact.FullName} - {contact.Company} ({contact.Email})");
            }

            // Example 7.3: Get inactive work contacts
            Console.WriteLine("\n--- Inactive Work Contacts ---");
            var inactiveWorkContacts = contacts
                .Where(c => !c.IsActive && c.Category == "Work")
                .ToList();
            DisplayContacts(inactiveWorkContacts);

            // Example 7.4: Get contacts without a company (individuals)
            Console.WriteLine("\n--- Individual Contacts (No Company) ---");
            var individualContacts = contacts
                .Where(c => c.Company == "")
                .Select(c => c.FullName)
                .ToList();
            foreach (var name in individualContacts)
            {
                Console.WriteLine($"  {name}");
            }

            // 8. CHAINED OPERATIONS
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("8. CHAINED OPERATIONS (Multiple LINQ Methods)");
            Console.WriteLine("═══════════════════════════════════════════════════════════");

            // Example 8.1: Filter, Sort, Select
            Console.WriteLine("\n--- Active Work Contacts Sorted by Name (Name & Email Only) ---");
            var chainedResult = contacts
                .Where(c => c.IsActive && c.Category == "Work")
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .Select(c => new { c.FullName, c.Email, c.Phone })
                .ToList();
            foreach (var contact in chainedResult)
            {
                Console.WriteLine($"  {contact.FullName}: {contact.Email} | {contact.Phone}");
            }

            // Example 8.2: Filter by category, group by company, count
            Console.WriteLine("\n--- Contact Distribution by Company in 'Work' Category ---");
            var workDistribution = contacts
                .Where(c => c.Category == "Work")
                .GroupBy(c => c.Company == "" ? "No Company" : c.Company)
                .Select(g => new { Company = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count);
            foreach (var group in workDistribution)
            {
                Console.WriteLine($"  {group.Company}: {group.Count} contact(s)");
            }

            // ═══════════════════════════════════════════════════════
            // SUMMARY
            // ═══════════════════════════════════════════════════════
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      SUMMARY                              ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("LINQ Operations Demonstrated:");
            Console.WriteLine("  ✅ Where()       - Filtering data");
            Console.WriteLine("  ✅ Select()       - Projecting/transforming data");
            Console.WriteLine("  ✅ OrderBy()     - Sorting ascending");
            Console.WriteLine("  ✅ ThenBy()      - Secondary sorting");
            Console.WriteLine("  ✅ OrderByDescending() - Sorting descending");
            Console.WriteLine("  ✅ Count()       - Counting elements");
            Console.WriteLine("  ✅ GroupBy()     - Grouping data");
            Console.WriteLine("  ✅ Distinct()    - Getting unique values");
            Console.WriteLine("  ✅ First/FirstOrDefault() - Getting first element");
            Console.WriteLine("  ✅ Chaining      - Multiple operations together");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Initialize sample contact data
        static List<Contact> InitializeContacts()
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

        // Helper method to display contacts in a formatted way
        static void DisplayContacts(List<Contact> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("  No contacts found.");
                return;
            }

            foreach (var contact in contacts)
            {
                string status = contact.IsActive ? "[Active]" : "[Inactive]";
                string company = string.IsNullOrEmpty(contact.Company) ? "(Individual)" : contact.Company;
                Console.WriteLine($"  {status} {contact.FullName,-20} | {contact.Email,-15} | {company,-15} | {contact.Category}");
            }
            Console.WriteLine($"  Total: {contacts.Count} contact(s)");
        }
    }
}
