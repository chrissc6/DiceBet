using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBet
{
    class GameClass
    {
        int chips = 5;



        public void OtherGame()

        {
            Random rng = new Random();
            
            int dice = 0;
            int total = 0;
            
            Console.WriteLine($"You have {chips} chips. \nPress ENTER to roll. (99 to Quit)");
            string answer = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"You have {chips} chips. Rolling...");

            while (answer != "99" || chips <= 0 || chips > 100)
            {
                int current = dice;
                string ans = "NA";

                total = Roll1();
                if (total == 7 || total == 11)
                {
                    ans = "Win";
                    
                    
                }
                else if (total == 2 || total == 3 || total == 12)
                {
                    ans = "Lose";
                    
                    
                }
                else
                {
                        Console.WriteLine($"You rolled a {total}, roll another {total} to win. Roll a 7 and lose.");
                        ans = Roll2(total);
                }

                
                if(ans == "Win")
                {
                    Console.WriteLine($"WINNER WINNER!!! You rolled a {total} (Chips +1)");
                    chips++;
                    if(chips > 100)
                    {
                        Console.WriteLine("\nThanks for playing");
                        Console.ReadKey();
                        break;
                    }
                    total = 0;
                    OtherGame();
                    break;
                }
                else
                {
                    Console.WriteLine($"Better luck next time. You rolled a {total} (Chips -2)");
                    chips = chips -2;
                    if(chips <= 0)
                    {
                        Console.WriteLine("\nThanks for playing");
                        Console.ReadKey();
                        break;
                    }
                    total = 0;
                    OtherGame();
                    break;
                }
    
            }
            Console.WriteLine("Thanks for playing");
            return;
            

        }


        private int Roll1()
        {
            
            Random rng = new Random();
            int die1 = rng.Next(1, 7);
            int die2 = rng.Next(1, 7);
            int total = die1 + die2;

            return total;
            
        }


        private string Roll2(int current)
        {
            int total2 = 0;
            int total3 = 0;
            Random rng = new Random();

            while (current != total2)
            {
                Console.WriteLine("Press ENTER to roll");

                Console.ReadKey();
                int die1 = 0;
                int die2 = 0;
                die1 = rng.Next(1, 7);
                die2 = rng.Next(1, 7);
                total2 = die1 + die2;
                int die3 = 0;
                int die4 = 0;
                die3 = rng.Next(1, 7);
                die4 = rng.Next(1, 7);
                total3 = die3 + die4;

                total2 = (total2 + total3) / 2;

                if (total2 != 7)
                {
                    Console.WriteLine($"You rolled a ....{total2}");
                    continue;
                }
                else
                {
                    Console.WriteLine("You rolled a 7 too late");
                    return "Lose";
                }
            }
            
            Console.WriteLine("You got it!");
            return "Win";
        }

    }
}
