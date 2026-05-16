using System;

namespace consoleapp;

public static class Program1
{
    public static void App()
    {
         bool running = true;
        string lastSentence = "";

        while (running)
        {
            Console.WriteLine("\n=== Sentence Repeater ===");

            // Ask user what they want
            Console.Write("Do you want to enter a new sentence? (y/n): ");
            string choice = (Console.ReadLine() ?? "").ToLower();

            if (choice == "y" || string.IsNullOrEmpty(lastSentence))
            {
                Console.Write("Enter sentence: ");
                lastSentence = Console.ReadLine() ?? "";
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
                Console.WriteLine($"{i}. {lastSentence}");
            }

            // Ask to continue
            Console.Write("\nDo you want to continue? (y/n): ");
            string again = (Console.ReadLine() ?? "").ToLower();

            running = (again == "y" || again == "yes");
        }

        Console.WriteLine("👋 Thanks!");
        Console.ReadLine();
    }
}
