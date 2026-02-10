using System;
// using System.Collections.Generic;

namespace Linq.Genery;



public class GenList
{
    // Generic static method - can work with any type
    public static List<T> CreateList<T>(List<T> list)
    {
        return list;
    }

}
