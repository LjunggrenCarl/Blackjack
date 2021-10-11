using System;
using System.Threading;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {

            Random r = new Random();
            string latestwinner = "nobudy has won yet";

            //Variablar
            int min = 1;
            int max = 11;
            int Cardsatstart = 2;

            Console.WriteLine("Welcome to Blackjack");

            string meny = "0";
            {
                //huvudmeny
                Console.WriteLine("Chose a option");
                Console.WriteLine("1. Play Blackjack");
                Console.WriteLine("2. Show the latest Winner");
                Console.WriteLine("3. Game Rules");
                Console.WriteLine("4. Quit");
                meny = Console.ReadLine();

                //Blankspace
                Console.WriteLine();

                switch (meny)
                {
                    // Spela en omgång av 21:an
                    case "1":
                        // Sätt player1points och Computerspoints till 0
                        int Computerspoints = 0;
                        int player1points = 0;

                        // Dra två kort per spelare
                        Console.WriteLine("You will now get two cards each"); 
                        
                        Thread.Sleep(1500);

                        for (int i = 1; i <= Cardsatstart; i++)
                        {
                            int computerscards = r.Next(min, max);
                            int player1cards = r.Next(min, max);

                            Computerspoints += computerscards;
                            player1points += player1cards;
                        }
                        // while (kortVal != "n" och player1points <= 21)
                        string Cardschoice = "";
                        while (Cardschoice != "n" && player1points <= 21)
                        {                            
                            
                            // Skriv ut poängställningen
                            Console.WriteLine($"Your points: {player1points}"); 
                            Thread.Sleep(1000);
                            Console.WriteLine($"Computers points: {Computerspoints}"); 
                            Thread.Sleep(1000);

                            // Fråga om spelaren vill ha ett till kort
                            Console.WriteLine("Do you want another card? (y/n)");

                            // Läs in Cardschoice
                            Cardschoice = Console.ReadLine();

                            // switch Cardschoice
                            switch (Cardschoice)

                            {
                                // case "y": Dra ett kort till
                                case "y":
                                    int newpoints = r.Next(1, 11); 
                                    player1points += newpoints;
                                    Console.WriteLine($"Your new cards are worth {newpoints} points"); 
                                    Thread.Sleep(1000);

                                    break;

                                // case "n": Gör ingenting (loopen kommer sluta köras)
                                case "n":
                                    break;

                                // default: Skriv att alternativet var ogiltigt
                                default:
                                    Console.WriteLine("You did not chose one of the options");
                                    break;

                            }

                        }


                        // Gå tillbaka till huvudmenyn om användaren har över 21
                        if (player1points > 21)
                        {
                            Console.WriteLine("You have more then 21 points and lost the game");
                            break;
                        }

                        // Datorn drar kort tills den vinner eller går över 21
                        while (Computerspoints < player1points && Computerspoints <= 21)
                        {
                            int Computersnewpoints = r.Next(1, 11);
                            Computerspoints += Computersnewpoints;
                            Console.WriteLine($"The computers drew a card worth {Computersnewpoints}");
                            Thread.Sleep(1000);
                        }

                        Console.WriteLine($"Your points: {player1points}");
                        Console.WriteLine($"Computers points: {Computerspoints}");

                        // Undersök vem som vann
                        if (Computerspoints > 21)
                        {
                            Console.WriteLine("You have won!");
                            Console.WriteLine("Type in your name");
                            latestwinner = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("The computer have won!");
                        }

                        break;

                    // Visa senaste vinnaren
                    case "2":
                        Console.WriteLine($"Latest Winner: {latestwinner}");
                        break;

                    // Visa spelets regler
                    case "3":
                        Console.WriteLine("Your goal is to force the computer to score more than 21 points.");
                        Console.WriteLine("You get points by drawing cards, each card has 1-10 points.");
                        Console.WriteLine("If you get more than 21 points, you lose.");
                        Console.WriteLine("Both you and the computer get two cards in the beginning. Then you get to");
                        Console.WriteLine("draw more cards until you are happy or get over 21.");
                        Console.WriteLine("When done, the computer draw cards until it has");
                        Console.WriteLine("more points than you or over 21 points.");
                        break;

                    // Gör ingenting (programmet avslutas)
                    case "4":
                        break;

                    default:
                        Console.WriteLine("You did not chose one of the options");
                        break;
                }

                Console.WriteLine();

            }

        }
    }
}
