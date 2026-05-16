using System;

namespace consoleapp;

public static class Program2
{
    public static void App()
    {
        bool running=true;
        string lastsentence="";
        while (running)
        {
            Console.WriteLine("welcome to program2");
            // ask user what dey want
            Console.Write("do u want a new sentence (y/n)? : ");
            string choice=(Console.ReadLine()??"").ToLower();

            if(choice=="y" || string.IsNullOrEmpty(lastsentence))
            {
                Console.Write("pls enter a sentence : ");
                 lastsentence=Console.ReadLine()??"";
            }
                     // Ask how many times
            Console.Write("How many times? ");
            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out int count) || count <= 0)
            {
                Console.WriteLine("❌ Please enter a valid positive number.");
                continue;
            }

            // Print result
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"{i}. {lastsentence}");
            }
            // to continue
            Console.Write("so do you want to play again");
            string again=(Console.ReadLine()??"").ToLower();
            running=(again=="y"||again=="yes");
        }
        Console.WriteLine("oh thanks for playing ");
        Console.ReadLine();
    }
}
