namespace NumberGuessGame
{
    class Program
    {
        public static int attempt = 0;
        public static string Player = "";
        private static string Player1; 
        private readonly static string Player2; 
        public string Player3 {get; set;}
        static void Main(string[] args)
        {
            Console.WriteLine("Hi welcome to number guess game");
            Console.Write("Pls enter a name:-> ");
            Player = Console.ReadLine()!.Trim();
            Console.WriteLine($"{Player} attempt = {attempt}");
            bool Isplaygame = true;
            while (Isplaygame)
            {
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
            bool isCorrect=false;

            while (!isCorrect)
            {
            Console.Write("I have a number in my mind guess the number from 1-100 :->");
            var userinput = Console.ReadLine();
            var usernumber=Convert.ToInt32(userinput);
                attempt++;
                if(usernumber>=1 && usernumber <= 100)
                {
                    if (usernumber == specialnumber)
                    {
                        Console.WriteLine($"Congrate {Player} won on {attempt} attempt");
                        isCorrect=true;
                    }else if (usernumber < specialnumber)
                    {
                        Console.WriteLine("too low try again");
                    }
                    else
                    {
                        Console.WriteLine("Too high try again");
                    }
                }
                else
                {
                    Console.WriteLine("pls pick anumber from 1-100");
                }
            }

            
        }
    }
}
