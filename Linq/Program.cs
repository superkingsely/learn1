using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Data;
using Linq.Entitiy;
using System.Text.Json;

namespace Linq
{

    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Display list");

            // var list =Datadb.Gen();
            // foreach (var item in list)
            // {
                
                
            //     Console.WriteLine($"{item.Id},{item}");
            // }

            // // Exercise 1 — Basic Filter
            // var orders = Datadb.Gen();

            // var startDate = new DateTime(2025, 1, 10);
            // var endDate = new DateTime(2025, 1, 11, 23, 59, 59);

            // var rc1Orders = orders
            //     .Where(o => o.IsPaid && !o.IsVoid)
            //     .Where(o => o.RevenueCenterId == "rc1")
            //     .Where(o => o.DateCreated >= startDate && o.DateCreated <= endDate)
            //     .Select(o => new
            //     {
            //         StaffName = $"{o.CreatedBy.FirstName} {o.CreatedBy.LastName}",
            //         o.TotalAmount,
            //         o.DateCreated
            //     })
            //     .OrderBy(o => o.DateCreated)
            //     .ToList(); 

            // Console.WriteLine("Exercise 1 — Paid, Non-Void Orders from Main Hall (rc1) between Jan 10-11, 2025");
            // Console.WriteLine("--------------------------------------------------------------------------");
            // foreach (var item in rc1Orders )
            // {
            //     Console.WriteLine(JsonSerializer.Serialize(item,new JsonSerializerOptions{WriteIndented=true}));
            //     Console.WriteLine($"{item.StaffName} | {item.TotalAmount} | {item.DateCreated}");
            // }
            // Console.WriteLine($"Total: {rc1Orders.Count} order(s)");

            List<Contact> contacts= Context.InitializeContacts();

            // Console.WriteLine(JsonSerializer.Serialize(contacts,new JsonSerializerOptions{WriteIndented=true}));
                foreach (var item in contacts)
                {
                    Console.WriteLine($"{item.Id} | {item.FullName }  | {item.Email} | {item.Phone} ");
                }
            Console.ReadKey();
        }

    }
}


// Contacts
// [
//   {
//     "Id": 1,
//     "FirstName": "John",
//     "LastName": "Doe",
//     "Email": "john@email.com",
//     "Phone": "555-1234",
//     "Company": "TechCorp",
//     "Category": "Work",
//     "IsActive": true,
//     "FullName": "John Doe"
//   },
//   {
//     "Id": 2,
//     "FirstName": "Jane",
//     "LastName": "Smith",
//     "Email": "jane@email.com",
//     "Phone": "555-5678",
//     "Company": "DesignStudio",
//     "Category": "Work",
//     "IsActive": true,
//     "FullName": "Jane Smith"
//   },
//   {
//     "Id": 3,
//     "FirstName": "Bob",
//     "LastName": "Johnson",
//     "Email": "bob@email.com",
//     "Phone": "555-9012",
//     "Company": "",
//     "Category": "Family",
//     "IsActive": true,
//     "FullName": "Bob Johnson"
//   },
//   {
//     "Id": 4,
//     "FirstName": "Alice",
//     "LastName": "Williams",
//     "Email": "alice@email.com",
//     "Phone": "555-3456",
//     "Company": "TechCorp",
//     "Category": "Work",
//     "IsActive": false,
//     "FullName": "Alice Williams"
//   },
//   {
//     "Id": 5,
//     "FirstName": "Charlie",
//     "LastName": "Brown",
//     "Email": "charlie@email.com",
//     "Phone": "555-7890",
//     "Company": "",
//     "Category": "Friend",
//     "IsActive": true,
//     "FullName": "Charlie Brown"
//   },
//   {
//     "Id": 6,
//     "FirstName": "Diana",
//     "LastName": "Miller",
//     "Email": "diana@email.com",
//     "Phone": "555-2345",
//     "Company": "StartupXYZ",
//     "Category": "Work",
//     "IsActive": true,
//     "FullName": "Diana Miller"
//   },
//   {
//     "Id": 7,
//     "FirstName": "Eve",
//     "LastName": "Davis",
//     "Email": "eve@email.com",
//     "Phone": "555-6789",
//     "Company": "TechCorp",
//     "Category": "Friend",
//     "IsActive": true,
//     "FullName": "Eve Davis"
//   },
//   {
//     "Id": 8,
//     "FirstName": "Frank",
//     "LastName": "Garcia",
//     "Email": "frank@email.com",
//     "Phone": "555-0123",
//     "Company": "",
//     "Category": "Family",
//     "IsActive": true,
//     "FullName": "Frank Garcia"
//   },
//   {
//     "Id": 9,
//     "FirstName": "Grace",
//     "LastName": "Martinez",
//     "Email": "grace@email.com",
//     "Phone": "555-4567",
//     "Company": "DesignStudio",
//     "Category": "Work",
//     "IsActive": false,
//     "FullName": "Grace Martinez"
//   },
//   {
//     "Id": 10,
//     "FirstName": "Henry",
//     "LastName": "Anderson",
//     "Email": "henry@email.com",
//     "Phone": "555-8901",
//     "Company": "StartupXYZ",
//     "Category": "Friend",
//     "IsActive": true,
//     "FullName": "Henry Anderson"
//   }
// ]