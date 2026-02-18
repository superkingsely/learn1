using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Data;
using Linq.Entitiy;

namespace Linq
{

    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Display list");

            List<Contact> contacts= Context.InitializeContacts();
                
                var list = contacts.Select(c => new
                {
                    firstname=c.FirstName,
                    FullName=c.FullName,
                    phone=c.Phone,
                    id=c.Id,
                    isactive=c.IsActive,
                    Company=c.Company,
                    category=c.Category

                }).Where(obj=>obj.category=="Work")
                .ToList();

            foreach (var item in list)
            {
                Console.WriteLine($"{item.id} | {item.FullName} | {item.phone} |{item.isactive} | {item.Company} | {item.category} ");

                // Console.WriteLine($"{item.category}"); 
                
            }
            Console.WriteLine($"List={list.Count()}");

            Console.ReadKey();
        }

        //   static void DisplayContacts(List<Contact> contacts)
        // {
        //     if (contacts.Count == 0)
        //     {
        //         Console.WriteLine("  No contacts found.");
        //         return;
        //     }

        //     foreach (var contact in contacts)
        //     {
        //         string status = contact.IsActive ? "[Active]" : "[Inactive]";
        //         string company = string.IsNullOrEmpty(contact.Company) ? "(Individual)" : contact.Company;
        //         Console.WriteLine($"  {status} {contact.FullName,-20} | {contact.Email,-15} | {company,-15} | {contact.Category}");
        //     }
        //     Console.WriteLine($"  Total: {contacts.Count} contact(s)");
        // }


    }
}
