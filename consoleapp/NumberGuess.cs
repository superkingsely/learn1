


namespace Name
{
    public static class NumberGuess
    {
        public static string userinput { get; set; } = "";
        public static string playername { get; set; } = "";

        public static void NumberGuessGame()
        {
            // Ask for player name
            while (true)
            {
                Console.Write("Please enter your name to play: ");

                playername = Console.ReadLine() ?? "USER";

                if (string.IsNullOrWhiteSpace(playername) || playername == "USER")
                {
                    Console.WriteLine("Please provide a valid name!");
                    continue;
                }

                break;
            }

            Console.WriteLine($"Welcome to my number guess game, enjoy {playername}!");

            Random random = new();

            bool playAgain = true;

            while (playAgain)
            {
                int specialnos = random.Next(1, 101);

                int guessnos = 0;

                // Main guessing loop
                while (true)
                {
                    Console.Write("Please enter your guess (1-100): ");

                    userinput = Console.ReadLine() ?? "";

                    bool isValidInput = int.TryParse(userinput, out guessnos);

                    if (!isValidInput)
                    {
                        Console.WriteLine("Invalid input. Numbers only.");
                        continue;
                    }

                    if (guessnos <= 0 || guessnos > 100)
                    {
                        Console.WriteLine("Choose a number between 1 and 100.");
                        continue;
                    }

                    if (guessnos == specialnos)
                    {
                        Console.WriteLine("Winner! Cool 😎");
                        break;
                    }
                    else if (guessnos < specialnos)
                    {
                        Console.WriteLine("Too small, try again.");
                    }
                    else
                    {
                        Console.WriteLine("Too big, try again.");
                    }
                }

                Console.Write($"Do you want to play again {playername}? [y/n]: ");

                userinput = Console.ReadLine() ?? "";

                playAgain =
                    userinput.ToLower() == "y" ||
                    userinput.ToLower() == "yes";
            }

            Console.WriteLine($"Thanks for playing {playername}");

            Console.ReadLine();
        }
    }
}



// namespace Name
// {
//    public static class NumberGuess
//     {
//         public static string userinput{get;set;}="";
//         public static string playername{get;set;}="";
//         public static void NumberGuessGame()
//         {
//             while (true)
//             {
                
//                 Console.Write("pls enter your name to play:");
//                 playername=Console.ReadLine()??"USER";
//                 if (playername == "" || playername == "USER")
//                 {
//                     Console.WriteLine("pls provide a name!");
//                     continue;
//                 }
//                 break;
//             }
            

//             Console.WriteLine($"welcome to my number guess game pls enjoy {playername}");
//             Random random= new();
//             // string userinput;
//             bool Playagain=true;
//             while (Playagain)
//             {
//              int specialnos=random.Next(1,101);
//                 int guessnos;
//              while (true)
//              {
                
//              Console.Write("pls enter ur guess nos here : "); 
//              userinput=Console.ReadLine()??"";  
//              bool isvalidinput=int.TryParse(userinput,out guessnos);
//                 if (!isvalidinput)
//                 {
//                     Console.WriteLine("invalid input pls insert numbers only");
//                     continue;
//                 }else if(guessnos <= 0)
//                 {
//                     Console.WriteLine("pls choose a number from 1-100");
//                     continue;
//                 }
//                 break;
//              }


//                 while (specialnos!=guessnos)
//                 {
//                     if (guessnos ==specialnos)
//                     {
//                         Console.WriteLine("winner! coool");
//                         break;

//                     }else if (guessnos < specialnos)
//                     {
//                         Console.WriteLine("oh too small try again");
//                         continue;

//                     }

//                         Console.WriteLine("too big try again");
//                         continue;
//                 }

//                 Console.Write($"dou wan to play again {playername} ? [y/n] ");
//                 userinput=Console.ReadLine()??"";
//                 Playagain=userinput.ToLower()=="y"||userinput.ToLower()=="yes";

//             };
//             Console.WriteLine($"thanks for playing {playername}");
//             Console.ReadLine();
//         }


//     } 
// }

