using System;
using System.Collections.ObjectModel;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            int balance ;
            int bet = 0;
            int number = 0;
            int section =0 ;
            int evenOrOdd = 0;
            string color = "";
            bool ext = false ;

            System.Console.WriteLine("Welcome To The Roulette");
            System.Console.WriteLine("Please Deposit your MONEY!!:\n");
            balance = int.Parse(Console.ReadLine());
            if ( balance < 0){
                System.Console.WriteLine("YOU ARE TOO BROKE BYE BYE !!!");
                ext = true;
            }

            while (ext) {
                
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
                        System.Console.WriteLine("Please insert the amount of the bet:");
                        bet = int.Parse(Console.ReadLine());
                        if (bet > balance || bet < 0)
                        {System.Console.WriteLine("Wrong input"); ext  = true;}
                        break;
                    case 2:
                        System.Console.WriteLine("Place your bet on a number between 0 - 36");
                        number = int.Parse(Console.ReadLine());
                        if ( number < 0 || number > 36)
                        {System.Console.WriteLine("wrong input"); ext = true;}
                        System.Console.WriteLine("Please insert the amount of the bet:");
                        bet = int.Parse(Console.ReadLine());
                        if (bet > balance || bet < 0)
                        {System.Console.WriteLine("Wrong input"); ext  = true;}
                        break;
                    case 3:
                        System.Console.WriteLine("Please choose a section to bet on");
                        System.Console.WriteLine("1)1-18\n2)19-36\n3)1-12\n4)13-24\n5)25-36");
                        section = int.Parse(Console.ReadLine());
                        if (section < 1 || section > 5)
                        {System.Console.WriteLine("wrong input"); ext = true;}
                        System.Console.WriteLine("Please insert the amount of the bet:");
                        bet = int.Parse(Console.ReadLine());
                        if (bet > balance || bet < 0)
                        {System.Console.WriteLine("Wrong input"); ext  = true;}
                        break;
                    case 4:
                        System.Console.WriteLine("Please select::\n1)EVEN\n2)ODD");
                        evenOrOdd = int.Parse(Console.ReadLine());
                        if (evenOrOdd < 1 || evenOrOdd > 2)
                        {System.Console.WriteLine("wrong input"); ext = true;}
                        System.Console.WriteLine("Please insert the amount of the bet:");
                        bet = int.Parse(Console.ReadLine());
                        if (bet > balance || bet < 0)
                        {System.Console.WriteLine("Wrong input"); ext  = true;}
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
                 var result = GenerateRandomNumberAndColor();
                switch (choice) {
                    case 1:

                        System.Console.WriteLine(result.Item1 + result.Item2);
                        if (color == result.Item2)
                        {
                            System.Console.WriteLine("You win!");
                            bet = bet * 2;
                            System.Console.WriteLine("$" + bet);
                            balance += bet ;
                        }
                        else
                        {
                            System.Console.WriteLine("You lose!");
                            balance -= bet ;
                        }
                        break;
                    case 2:
                        System.Console.WriteLine(result.Item1 + result.Item2);
                        if (number == result.Item1)
                        {
                            System.Console.WriteLine("You win!");
                            bet = bet * 35;
                            System.Console.WriteLine("$" + bet);
                            balance += bet ;
                        }
                        else
                        {
                            System.Console.WriteLine("You lose!");
                            balance -= bet ;
                        }
                        break;
                    case 3:
                        System.Console.WriteLine(result.Item1 + " " + result.Item2);
                        bool isWin = false;
                        switch (section)
                        {
                            case 1:
                                isWin = result.Item1 >= 1 && result.Item1 <= 18;
                                break;
                            case 2:
                                isWin = result.Item1 >= 19 && result.Item1 <= 36;
                                break;
                            case 3:
                                isWin = result.Item1 >= 1 && result.Item1 <= 12;
                                break;
                            case 4:
                                isWin = result.Item1 >= 13 && result.Item1 <= 24;
                                break;
                            case 5:
                                isWin = result.Item1 >= 25 && result.Item1 <= 36;
                                break;
                        }
                        if (isWin)
                        {
                            System.Console.WriteLine("You win!");
                            bet = bet * 3; // Assuming a 3x payout for section bets
                            System.Console.WriteLine("$" + bet);
                            balance += bet ;
                        }
                        else
                        {
                            System.Console.WriteLine("You lose!");
                            balance -= bet ;
                        }
                        break;
                    case 4:
                        System.Console.WriteLine(result.Item1 + " " + result.Item2);
                        bool isEven = result.Item1 % 2 == 0;
                        if ((evenOrOdd == 1 && isEven) || (evenOrOdd == 2 && !isEven))
                        {
                            System.Console.WriteLine("You win!");
                            bet = bet * 2;
                            System.Console.WriteLine("$" + bet);
                            balance += bet ;
                        }
                        else
                        {
                            System.Console.WriteLine("You lose!");
                            balance -= bet ;
                        }
                        break;
                    default:
                        System.Console.WriteLine("Wrong input");
                        ext = true;
                        break;
                }

                //Check if balance 0
                if (balance <= 0)
                {
                    System.Console.WriteLine("You are out of money! Game over.");
                    ext = true;
                }
            }
        }
    }
}