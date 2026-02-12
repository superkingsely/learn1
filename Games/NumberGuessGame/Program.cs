namespace NumberGuessGame
{
    class Program
    {
        public static int attempt = 0;
        public static string Player = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Hi welcome to number guess game");
            Console.Write("Pls enter a name:-> ");
            Player = Console.ReadLine()!.Trim();
            Console.WriteLine($"{Player} attempt = {attempt}");
            bool Isplaygame = true;
            while (Isplaygame)
            {
                attempt++;
                RunGame();
                Isplaygame = ShouldPlaygame();
            }
            Console.WriteLine($"Thanks for playing {Player} ");
            Console.ReadKey();
        }

        static bool ShouldPlaygame()
        {
            Console.Write("Do you want to try again:->(y/n) ");
            var req = Console.ReadLine()!.ToLower().Trim();
            if (req.Length != 1)
            {
                Console.WriteLine("come on just y or n");
                return ShouldPlaygame();
            }
            else if (string.IsNullOrEmpty(req))
            {
                Console.WriteLine("pls enter a value");
                return ShouldPlaygame();
            }

            if (req == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void RunGame()
        {
            var rand = new Random();
            var specialnumber = rand.Next(1, 100);
            Console.Write("I have a number in my mind guess the number from 1-100 :->");
            var userinput = Console.ReadLine();

            // ISSUE 1: Missing null/empty check before Convert.ToInt32 - this will crash if user enters nothing
            // WRONG: Your code checked for empty but didn't return, so it continued to Convert.ToInt32(null)
            if (string.IsNullOrEmpty(userinput))
            {
                Console.WriteLine("pls enter a number here is empty try again ");
                return; // FIXED: Added return to exit the method
            }

            try
            {
                var usernum = Convert.ToInt32(userinput);

                // ISSUE 2: Range validation should come BEFORE comparing with specialnumber
                // WRONG: Your code had range check AFTER the comparison, which doesn't make sense
                // ISSUE 3: Your condition "usernum<=1&& usernum >= 100" is logically impossible!
                // A number cannot be both <= 1 AND >= 100 at the same time
                // WRONG: else if(usernum<=1&& usernum >= 100)
                // FIXED: Changed to proper range check using OR operator
                if (usernum < 1 || usernum > 100)
                {
                    Console.WriteLine("just pick a number from 1-100 pls");
                    return; // FIXED: Return instead of calling ShouldPlaygame - let main loop handle replay
                }

                // ISSUE 4: After correct guess, no return statement so game continues
                // WRONG: You called ShouldPlaygame() but didn't return, so code continued
                if (usernum == specialnumber)
                {
                    Console.WriteLine($"Congrate you won {Player ?? "anonymous lolz..."} ");
                    return; // FIXED: Return to exit game properly
                }
                else if (usernum < specialnumber)
                {
                    Console.WriteLine("Too low try again");
                }
                else if (usernum > specialnumber)
                {
                    Console.WriteLine("Too High try again");
                }
            }
            catch (FormatException)
            {
                // ISSUE 5: Fixed catch block - caught specific FormatException instead of generic Exception
                // This handles the case when user enters non-numeric input
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
            catch (Exception e)
            {
                // Generic catch for any other unexpected errors
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}
