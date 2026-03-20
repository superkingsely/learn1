using System;

namespace NumberGuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playagain=true;
            Console.Write("pls enter player name :-> ");
            string username=Console.ReadLine();
            string playername=string.IsNullOrEmpty(username)?"Boss":username;
            Console.WriteLine($"welcome to number guess game {playername} enjoy pls");
            while (playagain)
            {
                Random rand=new Random();
                int spnos=rand.Next(1,101);
                int attempt=0;
                bool iscorrect=false;
                while (!iscorrect)
                {
                    Console.Write("pls pick a no from 1-100 :-> ");
                    bool ispick=int.TryParse(Console.ReadLine(),out int userinput);
                    if (!ispick)
                    {
                        Console.WriteLine("invalid value");
                        continue;
                    }
                    if (userinput < 1 || userinput > 100)
                    {
                        Console.WriteLine("pls choose a number from 1-100 pls");
                        continue;
                    }
                    attempt++;
                    if (userinput > spnos)
                    {
                        Console.WriteLine("too high");
                    }else if (userinput < spnos)
                    {
                        Console.WriteLine("too low");
                    }
                    else
                    {
                        Console.WriteLine("yeeeeh correct boss");
                        Console.WriteLine($"attempt : {attempt}");
                        iscorrect=true;
                    }
                }
                Console.Write("do you wan to play agina y/n :");
                string ans=Console.ReadLine().ToLower();
                playagain= ans=="y"||ans=="yes";
            }
            Console.WriteLine($"thanks for playing this nice game {playername}");
        }
    }
}