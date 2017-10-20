using System;
using System.Threading;

namespace Hunter_X_Hunter_part_2
{
    //This object will be where the battle logic takes place
    class Arena
    {
        static Random rnd = new Random();


        //The Battle method will be used to conduct battle logic and determine a winner
        //It will be passed two parameters which are fighter objects
        //It will return a bool true if the player wins or false if the comp wins
        public bool Battle(Fighter fighter1, Fighter fighter2)
        {
            bool winner;

            bool firstMove;
            int round = 1;
            string f1name = fighter1.Name;
            string f2name = fighter2.Name;

            //declare battle and print fighters names
            Console.WriteLine($"The battle begins between {fighter1.Name} and {fighter2.Name} \n");
            Thread.Sleep(1000);

            //If your enemy is Tompa 
            if (fighter2.Name == "Tompa")
            {
                Console.WriteLine("Tompa scowls at you menacingly");
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                }

                Console.WriteLine("Tompa forfeits");

                //return a victory
                return true;
            }


            //keep fighting until one player KOs
            while (fighter1.Health > 0 && fighter2.Health > 0)
            {
                //reset the moves

                Console.WriteLine($"Round number {round} begins");
                Thread.Sleep(500);

                Console.WriteLine($"[{fighter1.Name}] has {fighter1.Health} health; and [{fighter2.Name}] has {fighter2.Health} health");

                //Calculate who goes first
                firstMove = CalcTurn(fighter1, fighter2);

                //If the player moves first
                if (firstMove == true)
                {
                    Console.WriteLine($"[{fighter1.Name}] has the firstmove");
                    PlayerTurn(fighter1, fighter2);
                    Console.WriteLine($"[{fighter2.Name}] now moves");
                    CompTurn(fighter1, fighter2);
                }
                else if (firstMove == false)
                {
                    Console.WriteLine($"[{fighter2.Name}] has the firstmove");
                    CompTurn(fighter1, fighter2);
                    Console.WriteLine($"[{fighter1.Name}] now has the initiative");
                    PlayerTurn(fighter1, fighter2);
                }

                round = round + 1;
            }


            //Once one of the fighter's health drops below zero set the winner code to return 
            if (fighter1.Health <= 0)
            {
                winner = false;
            }
            else
            {
                winner = true;
            }

            return winner;
        }




        //The players turn
        static void PlayerTurn(Fighter f1, Fighter f2)
        {
            //variables needed for battle

            string move = null;

            while (move != "attack" && move != "brace" && move != "charge")
            {
                Console.WriteLine("Select [attack], [brace], or [charge]\n");
                move = Console.ReadLine();

                //Decisions based on move
                if (move == "attack")
                {
                    f1.Attack(f2);
                }
                else if (move == "brace")
                {
                    f1.Brace();
                    Thread.Sleep(800);

                }
                else if (move == "charge")
                {
                    f1.Charge();
                    Thread.Sleep(800);
                }

            }
        }





        //The Computer's turn
        static void CompTurn(Fighter f1, Fighter f2)
        {
            //calculate computer's move at random 50% chance they will attack, 20% charge, and 30% brace
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




        //Method to calculate turn order
        static bool CalcTurn(Fighter f1, Fighter f2)
        {
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
