// NUMBER GUESS GAME - C# Learning Project
using System;

namespace NumberGuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            RunGame();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void RunGame()
        {
            Console.WriteLine("=== NUMBER GUESS GAME ===");
            Console.WriteLine("Guess a number between 1-100!");
            
            Random random = new Random();
            int secretNumber = random.Next(1, 101);
            int attempts = 0;
            bool isCorrect = false;

            while (!isCorrect)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int guess))
                {
                    if (guess >= 1 && guess <= 100)
                    {
                        attempts++;

                        if (guess == secretNumber)
                        {
                            Console.WriteLine($"Correct! The number was {secretNumber}");
                            Console.WriteLine($"Attempts: {attempts}");
                            isCorrect = true;
                        }
                        else if (guess > secretNumber)
                        {
                            Console.WriteLine("Too HIGH!");
                        }
                        else
                        {
                            Console.WriteLine("Too LOW!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a number between 1-100");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a whole number.");
                }
            }

            Console.WriteLine("=== GAME OVER ===");
        }
    }
}

// C# CONCEPTS LEARNED:
// - Variables (int, bool, Random)
// - Console I/O (WriteLine, ReadLine)
// - Type conversion (int.TryParse)
// - Random.Next(min, max)
// - if/else if/else conditions
// - while loops
// - Comparison operators (==, >, <)
