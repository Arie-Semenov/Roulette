using System;
using System.Collections.ObjectModel;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            int balance ;
            int bet;
            int section;
            int evenOrOdd;
            string color;
            bool win;
            bool ext = false ;

            while (ext) {
                System.Console.WriteLine("Welcome To The Roulette");
                System.Console.WriteLine("Please Deposit your MONEY!!:\n");
                balance = int.Parse(Console.ReadLine());
                if ( balance < 0){
                    System.Console.WriteLine("YOU ARE TOO BROKE BYE BYE !!!");
                    ext = true;
                }
                System.Console.WriteLine("Your balance is:" + balance);
                System.Console.WriteLine("Please select one of the options:");
                System.Console.WriteLine("1)Bet on COLOR\n2)Bet on Number\n3)Bet on a SECTION\n4)Bet on EVEN or ODD\n5)EXIT");
                int choice = int.Parse(Console.ReadLine());
                //menu options
                switch (choice){
                    case 1:
                        System.Console.WriteLine("What color would you like to bet ?\nRed Black Green");
                        color = Console.ReadLine().ToLower();
                        if (color != "red" || color != "black" || color != "green")
                        {System.Console.WriteLine("wrong input"); ext = true;}
                        break;
                    case 2:
                        System.Console.WriteLine("Place your bet on a number between 0 - 36");
                        bet = int.Parse(Console.ReadLine());
                        if ( bet < 0 || bet > 36)
                        {System.Console.WriteLine("wrong input"); ext = true;}
                        break;
                    case 3:
                        System.Console.WriteLine("Please choose a section to bet on");
                        System.Console.WriteLine("1)1-18\n2)19-36\n3)1-12\n4)13-24\n5)25-36");
                        section = int.Parse(Console.ReadLine());
                        if (section < 1 || section > 5)
                        {System.Console.WriteLine("wrong input"); ext = true;}
                        break;
                    case 4:
                        System.Console.WriteLine("Please select::\n1)EVEN\n2)ODD");
                        evenOrOdd = int.Parse(Console.ReadLine());
                        if (evenOrOdd < 1 || evenOrOdd > 2)
                        {System.Console.WriteLine("wrong input"); ext = true;}
                        break;
                    case 5:
                        System.Console.WriteLine("Thanks for playing see you again\nBalance:" + balance);
                        ext = true;
                        break;
                    default:
                        System.Console.WriteLine("WRONG INPUT");
                        ext = true;
                        break;
                }
                
                //Roulette function
                static (int, string) GenerateRandomNumberAndColor()
                {
                    Random random = new Random();
                    string[] colors = { "green", "red", "black" };
                    string color = colors[random.Next(colors.Length)];

                    int number = color == "green" ? 0 : random.Next(1, 37);

                    return (number, color);
                }

                //calculating win or lose and how much mony
                switch (choice) {
                    case 1:
                        
                        break;
                    
                    default:
                        break;
                }
            }
        }
    }
}