using System;

namespace consoleapp;

public static class FizzBuzz
{
    public static void Cal()
    {
        bool playagain;
        do
        {
            
        string userinput;
        Console.WriteLine("welcome to my fizzbuzz app");
        while (true)
        {
            
            Console.Write("Do u want an instruction on hw the fizzbuzz  work (y/n):?");
            userinput=Console.ReadLine()??"";
            if (userinput.ToLower() == "y" || userinput.ToLower() == "yes")
            {
                Console.WriteLine("The FizzBuzz game here , u input any number and the system will help u identify the fizz and buzz of the inputed nos \n note: if its fizz means that nos is divisible by 3 and if its buzz the nos is divisible by 5 and if it is fizzbuzz means the nos is divisible by both 3 and 5 ");
                
            }else if(userinput.ToLower()=="n"|| userinput.ToLower() == "no")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input here pls just enter a => yes/no ");
                    continue;
                }
            break;
        }

        int fizzbuzznos;
        while (true)
        {
            
            Console.Write("alright pls enter a number for a fizzbuzz ");
            userinput=Console.ReadLine()??"";
            bool isvalid=int.TryParse(userinput,out  fizzbuzznos);

            if (!isvalid)
            {
                Console.WriteLine($"ur value {userinput}' is invalid pls enter a number only thank u");
                continue;
            }else if (fizzbuzznos <= 0)
            {
                Console.WriteLine("pls enter a number greater than zero pls thank u");
                continue;
            }
            break;
        }

        int fizz=0;
        int buzz=0;
        int fizzbuzz=0;

        for(int i = 1; i <= fizzbuzznos; i++)
        {
            // if (i % 3 == 0 && i % 5 == 0)
            // {
            //     Console.WriteLine("FizzBuzz");
            // }

            switch (i)
            {
                case int n when n %3==0 && n%5==0:
                    fizzbuzz++;
                    Console.WriteLine("FizzBuzz");
                    break;
                case int n when n %3==0:
                    fizz++;
                    Console.WriteLine("Fizz");
                    break;
                case int n when n%5==0:
                    buzz++;
                    Console.WriteLine("Buzz");
                    break;
                default:
                Console.WriteLine(i);
                break;
            }
        }
        Console.WriteLine("==================");
        Console.WriteLine($"The end you have your count: \n =>  Fizz={fizz}, buzz={buzz} and FizzBuzz={fizzbuzz}");
        Console.WriteLine("so do u want to try again with another number (y/n) ?:");
        userinput=Console.ReadLine()??"";
        playagain=(userinput.ToLower()=="y" || userinput.ToLower()=="yes");
        }while(playagain);

        Console.WriteLine("thanks for ur time with us we appreciate u");
        Console.ReadLine();
    }
}
