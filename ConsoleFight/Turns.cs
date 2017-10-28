using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_X_Hunter_part_2
{
    class Turns
    {

        static Random rnd = new Random();
        //The players turn

        public static void PlayerTurn(Fighter f1, Fighter f2)
        {    //variables needed for battle

            string move = null;

            while (move != "attack" && move != "brace" && move != "charge")
            {

                Console.WriteLine("Select [attack], [brace], or [charge]\n");
                move = Console.ReadLine();

                // decisions based on move
                if (move == "attack")
                {
                    f1.Attack(f2);
                }
                else if (move == "brace")
                {
                    f1.Brace();
                    System.Threading.Thread.Sleep(800);

                }
                else if (move == "charge")
                {
                    f1.Charge();
                    System.Threading.Thread.Sleep(800);
                }

            }
        }
        //computer's turn
        public static void CompTurn(Fighter f1, Fighter f2)
        {   //calculate computer's move at frandom 50% chance they will attack, 20% charge, and 30% brace
            int chance = rnd.Next(1, 101);
            if (chance > 0 && chance <= 20)
            {
                f2.Charge();

            }
            else if (chance > 20 && chance <= 50)
            {
                f2.Brace();
            }
            else
            {
                f2.Attack(f1);
            }


        }
    }
}
// Shania
// method to calculate turn order
static bool CalcTurn(Fighter f1, Fighter f2);
//calculate the turn order which is a random number from 1-10 + character's speed stat
int playerSpeed;
int compSpeed;
playerSpeed = rnd.Next(1, 11) + f1.Speed;
            compSpeed = rnd.Next(1, 11) + f2.Speed;
            if (playerSpeed > compSpeed)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}