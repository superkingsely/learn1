using System;

namespace consoleapp;

public static class Times
{
    public static void Cal()
    {
        Console.WriteLine("welcome to my time-table app");
        bool playagain=true;
        string userinput="";
        do
        {
            int timesvalue;
            while (true)
            {
                Console.Write("what time-table do u want to write");
                userinput=Console.ReadLine()??"";
                bool timetable=int.TryParse(userinput,out  timesvalue);
                if (!timetable || timesvalue <= 0 )
                {
                    Console.WriteLine($"pls enter Numbers and not letter or words, '{userinput}' is invalid : \n thanks");
                    continue;
                }
                break;
            }
            int limitvalue;
           while (true)
           {
                 Console.Write($"Cool!! i.e from {timesvalue} X 2 to {timesvalue} X what? ");
                userinput=Console.ReadLine()??"";
                bool limit=int.TryParse(userinput,out  limitvalue);
                if (!limit || limitvalue <= 0 )
                {
                    Console.WriteLine($"pls enter Numbers and not letter or words, '{userinput}' is invalid : \n thanks");
                    continue;
                }
                break;
           }

            for(int i = 1; i <= limitvalue; i++)
            {
                int answer=timesvalue*i;
                Console.WriteLine($"{timesvalue} X {i} = {answer}");
            }
                Console.WriteLine("the end");
                Console.Write("so do u want to write another times again (y/n)? : ");
                string again =Console.ReadLine()??"";

                playagain=(again.ToLower()=="y" || again.ToLower()=="yes");
            
        }while(playagain);
        Console.WriteLine("thanks we apprecaite u smiles....");
        Console.ReadLine();
    }
}
