using System;
using System.Threading;

namespace Hunter_X_Hunter_part_2
{
    //This object will be where the battle logic takes place
    class Arena
    {
        //these class variables are accessible by multiple methods()
        //They represent the brace and charge state of the players
        //Later I will move them to properties of the fighter class but 
        //I wanted to demostrate scoping
        //Also the "static" keyword must be used here so they can be accessed in a generic case
        static bool brace1;
        static bool brace2;
        static bool charge1;
        static bool charge2;
        static Random rnd = new Random();


        //The Battle method will be used to conduct battle logic and determine a winner
        //It will be passed two parameters which are fighter objects
        //It will return a bool true if the player wins or false if the comp wins
        public bool Battle(Fighter fighter1, Fighter fighter2)
        {
            bool winner;
            string move1;
            string move2;

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
                move1 = "null";
                move2 = "null";

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
            int playerAtk;
            int compDef;
            string move = null;
            int result = 0;
            int damage = 0;

            while (move != "attack" && move != "brace" && move != "charge")
            {
                Console.WriteLine("Select [attack], [brace], or [charge]\n");
                move = Console.ReadLine();

                //Decisions based on move
                if (move == "attack")
                {
                    Console.WriteLine($"[{f1.Name}] attacks!\n");
                    Thread.Sleep(500);
                    //calculate attack which is a random int from 1-10 + the stat
                    playerAtk = rnd.Next(1, 11) + f1.Atk;

                    //if player used charge their attack increases by 25%
                    if (charge1 == true)
                    {
                        playerAtk = playerAtk + playerAtk / 4;
                    }

                    //calculate computer defense a random number between 1-8 + the stat
                    compDef = rnd.Next(1, 9) + f2.Def;

                    //if the computer used brace their defense increases by %50
                    if (brace2 == true)
                    {
                        compDef = compDef + compDef / 2;
                    }

                    //if the comp used charge thier defense drops by 50%
                    else if (charge2 == true)
                    {
                        compDef = compDef / 2;
                    }

                    //Calculate the results of the move
                    result = playerAtk - compDef;

                    //Decisions based on result
                    if (result > -5 && result <= 0)
                    {
                        Console.WriteLine($"[{f2.Name}] deflects [{f1.Name}'s] attack\n");
                        Thread.Sleep(500);
                    }
                    else if (result < -5)
                    {
                        Console.WriteLine($"[{f2.Name}] counters!\n");
                        Thread.Sleep(500);
                        //calculate damage based on the fighters low and high damage bounds
                        damage = rnd.Next(f2.CounterL, f2.CounterH + 1);

                        Console.WriteLine($"[{f1.Name}] takes [{damage}] damage\n");
                        Thread.Sleep(500);
                        //deal damage to the player object
                        f1.Damage(damage);
                    }
                    else if (result > 0)
                    {
                        Console.WriteLine($"[{f1.Name}] lands a hit!\n");
                        Thread.Sleep(500);

                        damage = rnd.Next(f1.DamL, f1.DamH + 1);
                        //if charge was used add 50% damage
                        if (charge1 == true)
                        {
                            damage = damage + damage / 2;
                        }
                        Console.WriteLine($"[{f2.Name}] takes {damage} damage\n");
                        Thread.Sleep(500);

                        f2.Damage(damage);
                    }

                    //reset player's charge & brace
                    charge1 = false;
                    brace1 = false;
                    //reset comps brace
                    brace2 = false;

                }
                else if (move == "brace")
                {
                    Console.WriteLine($"[{f1.Name}] braces for defense\n");
                    Thread.Sleep(800);
                    brace1 = true;
                    //reset charge
                    charge1 = false;
                }
                else if (move == "charge")
                {
                    Console.WriteLine($"[{f1.Name}] prepares their strength for the next attack\n");
                    Thread.Sleep(800);
                    charge1 = true;
                    // reset brace
                    brace1 = false;
                }

            }
        }





        //The Computer's turn
        static void CompTurn(Fighter f1, Fighter f2)
        {
            //variables needed for battle
            int compAtk;
            int playerDef;
            string move = "null";
            int result = 0;
            int damage = 0;


            //calculate computer's move at random 50% chance they will attack, 20% charge, and 30% brace
            int chance = rnd.Next(1, 101);
            if (chance > 0 && chance <= 20)
            {
                move = "charge";
            }
            else if (chance > 20 && chance <= 50)
            {
                move = "brace";
            }
            else
            {
                move = "attack";
            }


            //Decisions based on move
            if (move == "attack")
            {
                Console.WriteLine($"[{f2.Name}] attacks!\n");
                Thread.Sleep(500);
                //calculate attack which is a random int from 1-10 + the stat
                compAtk = rnd.Next(1, 11) + f2.Atk;

                //if comp used charge their attack increases by 25%
                if (charge2 == true)
                {
                    compAtk = compAtk + compAtk / 4;
                }

                //calculate player defense a random number between 1-8 + the stat
                playerDef = rnd.Next(1, 9) + f1.Def;

                //if the player used brace their defense increases by %50
                if (brace1 == true)
                {
                    playerDef = playerDef + playerDef / 2;
                }

                //if the player used charge thier defense drops by 50%
                else if (charge1 == true)
                {
                    playerDef = playerDef / 2;
                }

                //Calculate the results of the move
                result = compAtk - playerDef;

                //Decisions based on result
                if (result > -5 && result <= 0)
                {
                    Console.WriteLine($"[{f1.Name}] deflects [{f2.Name}'s] attack\n");
                    Thread.Sleep(500);
                }
                else if (result < -5)
                {
                    Console.WriteLine($"[{f1.Name}] counters!\n");
                    Thread.Sleep(500);
                    //calculate damage based on the fighters low and high damage bounds
                    damage = rnd.Next(f1.CounterL, f1.CounterH + 1);
                    Console.WriteLine($"[{f2.Name}] takes {damage} damage\n");
                    Thread.Sleep(500);
                    //deal damage to the comp fighter object
                    f2.Damage(damage);
                }
                else if (result > 0)
                {
                    Console.WriteLine($"[{f2.Name}] lands a hit!\n");
                    Thread.Sleep(500);
                    damage = rnd.Next(f2.DamL, f2.DamH + 1);
                    //if charge was used add 50% damage
                    if (charge1 == true)
                    {
                        damage = damage + damage / 2;
                    }

                    Console.WriteLine($"[{f1.Name}] takes {damage} damage\n");
                    Thread.Sleep(500);
                    f1.Damage(damage);

                }

                //reset comp's charge and brace
                charge2 = false;
                brace2 = false;
                //reset player's brace
                brace1 = false;
            }
            else if (move == "brace")
            {
                Console.WriteLine($"[{f2.Name}] braces for defense\n");
                Thread.Sleep(800);
                brace2 = true;
                //reset comp's charge
                charge2 = false;
            }
            else if (move == "charge")
            {
                Console.WriteLine($"{f2.Name} prepares their strength for the next attack\n");
                Thread.Sleep(800);
                charge2 = true;
                //reset comp's brace
                brace2 = false;
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
