using System;

namespace Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        var genlist=Genery.GenList.CreateList(nums);
        var query = genlist.Where(n => n > 5);  // NOT executed yet
        foreach (var item in query)
        {
        Console.WriteLine($"Query created, but not executed {item} ");
            
        }
        genlist.Add(11);  // Modify source!
        genlist.Add(12);
        var result = query.ToList();
        foreach (var item in result)
        {
            
        Console.WriteLine($"result= {item} ");
        }

        Console.ReadKey();
    }
}
