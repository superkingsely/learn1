


// var word="Hello world";
// -------------------------------
// data type:
// string--- e.g "hello"
// integer---numbers
// -------------------------------
// operator
// +,-,*,/,%
namespace consoleapp;

public class Program
{
	public static void Main()
	{
		Console.WriteLine("okay");


        static void Name(out string name)
        {
            name = Console.ReadLine();
        }

        Name(out string name);
        Console.WriteLine("Hello " + name);
        
		Console.ReadLine();
	}
}