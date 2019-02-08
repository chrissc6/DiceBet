using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBet
{
    class GameClass
    {

        int chips = 10;
        int bonus = 0;
        int point = 0;
        int dice = 0;
        int total;

        public void OtherGame()
        {
            Random rng = new Random();
            Console.WriteLine($"start");
            var answer = Console.ReadLine();

            while (answer != "99")
            {
                Console.WriteLine($"You have {chips} chips. Press ENTER to roll. (99 to Quit)");
                answer = Console.ReadLine();

                (bonus, dice) = Roll1(0);
                if (bonus == 1)
                {
                    chips++;
                    Console.WriteLine($"WINNER WINNER!!! You rolled a {dice} (Chips +1)");
                    dice = 0;
                    bonus = 0;
                    continue;
                }
                else if (bonus == -1)
                {
                    chips--;
                    Console.WriteLine($"Better luck next time. You rolled a {dice} (Chips -1)");
                    dice = 0;
                    bonus = 0;
                    continue;
                }
                else
                {
                    point++;
                    Console.WriteLine($"You rolled a {dice}, roll another {dice} to win");
                    bonus = 0;
                    dice = Roll2(dice);
                }

                


            }

            
        }


        private (int, int) Roll1(int bonus)
        {
            Random rng = new Random();
            int die1 = rng.Next(1, 7);
            int die2 = rng.Next(1, 7);
            bonus = 0;
            point = 0;
            total = die1 + die2;

            if (total == 7 || total == 11)
            {
                return (bonus++, total);
            }
            else if(total == 2 || total == 3 || total == 12)
            {
                return (bonus--, total);
            }
            else
            {
                return (bonus = 0, total);
            }
        }


        private int Roll2(int dice)
        {
            Random rng = new Random();
            int die1 = rng.Next(1, 7);
            int die2 = rng.Next(1, 7);
            bonus = 0;
            point = 0;
            //int rdice = dice;
            total = die1 + die2;

            if (total == dice)
            {
                return bonus++;
            }
            else if (total != 7)
            {
                ;
            }
            else
            {
                return bonus--;
            }
        }
    }
}
