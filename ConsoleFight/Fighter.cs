using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hunter_X_Hunter_part_2
{
    class Fighter
    {
        //define all the class variables first these should be private
        private string name;
        private int health;
        private int atk;
        private int damL;
        private int damH;
        private int def;
        private int speed;
        private int counterL;
        private int counterH;
        private bool isBracing;
        private bool isCharging;

        static Random rnd = new Random();

        //now properties which allow us to safely manipulate our variables
        //properties have getters and setters
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Atk
        {
            get { return atk; }
            set { atk = value; }
        }

        public int DamL
        {
            get { return damL; }
            set { damL = value; }
        }

        public int DamH
        {
            get { return damH; }
            set { damH = value; }
        }

        public int Def
        {
            get { return def; }
            set { def = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int CounterL
        {
            get { return counterL; }
            set { counterL = value; }
        }

        public int CounterH
        {
            get { return counterH; }
            set { counterH = value; }
        }

        public bool Bracing
        {
            get { return isBracing; }
            set { isBracing = value; }
        }

        public bool Charging
        {
            get { return isCharging; }
            set { isCharging = value; }
        }

        // add our constructor
        public Fighter(string fname)
        {
            //set up the fighters based on their name
            if (fname == "Gon")
            {
                Name = "Gon";
                Atk = 5;
                DamL = 1;
                DamH = 4;
                Def = 5;
                Speed = 10;
                Health = 10;
                CounterL = 3;
                CounterH = 5;
            }

            else if (fname == "Hanzo")
            {
                Name = "Hanzo";
                Atk = 7;
                DamL = 1;
                DamH = 5;
                Def = 3;
                Speed = 5;
                Health = 10;
                CounterL = 1;
                CounterH = 2;
            }

            else if (fname == "Hizoka")
            {
                Name = "Hizoka";
                Atk = 9;
                DamL = 2;
                DamH = 6;
                Def = 6;
                Speed = 7;
                Health = 12;
                CounterL = 1;
                CounterH = 6;
            }

            else if (fname == "Tompa")
            {
                Name = "Tompa";
                Atk = 0;
                DamL = 0;
                DamH = 0;
                Def = 0;
                Speed = 0;
                Health = 0;
                CounterL = 0;
                CounterH = 0;
            }

            //If no name is given, default to these stats
            else
            {
                Name = "That guy";
                Atk = 0;
                DamL = 0;
                DamH = 0;
                Def = 0;
                Speed = 0;
                Health = 0;
                CounterL = 0;
                CounterH = 0;
            }

        }
        //end contstructor


        public void Attack(Fighter f2)
        {
            //calculate damage

            //battle vars
            int fAtk;
            int opponentDef;
            int result = 0;
            int damage = 0;
            Console.WriteLine($"[{Name}] attacks!\n");
            Thread.Sleep(500);
            //calculate attack which is a random int from 1-10 + the stat
            fAtk = rnd.Next(1, 11) + this.Atk;

            //if this fighter used charge their attack increases by 25%
            if (isCharging == true)
            {
                fAtk = fAtk + fAtk / 4;
            }

            //calculate opponent defense a random number between 1-8 + the stat
            opponentDef = rnd.Next(1, 9) + f2.Def;

            //if the opponent used brace their defense increases by %50
            if (f2.Bracing == true)
            {
                opponentDef = opponentDef + opponentDef / 2;
            }

            //if the opponent used charge thier defense drops by 50%
            else if (f2.Charging == true)
            {
                opponentDef = opponentDef / 2;
            }

            //Calculate the results of the move
            result = fAtk - opponentDef;

            //Decisions based on result
            if (result > -5 && result <= 0)
            {
                Console.WriteLine($"[{f2.Name}] deflects [{Name}'s] attack\n");
                Thread.Sleep(500);
            }
            else if (result < -5)
            {
                Console.WriteLine($"[{f2.Name}] counters!\n");
                Thread.Sleep(500);
                //calculate damage based on the fighters low and high damage bounds
                damage = rnd.Next(f2.CounterL, f2.CounterH + 1);

                Console.WriteLine($"[{Name}] takes [{damage}] damage\n");
                Thread.Sleep(500);
                //deal damage to this fighter
                this.Damage(damage);
            }
            else if (result > 0)
            {
                Console.WriteLine($"[{Name}] lands a hit!\n");
                Thread.Sleep(500);

                damage = rnd.Next(DamL, DamH + 1);
                //if charge was used add 50% damage
                if (isCharging == true)
                {
                    damage = damage + damage / 2;
                }
                Console.WriteLine($"[{f2.Name}] takes {damage} damage\n");
                Thread.Sleep(500);

                f2.Damage(damage);
            }

            //reset player's charge & brace
            isBracing = false;
            isCharging = false;
            //reset comps brace
            f2.Bracing = false;

        }


        public void Brace()
        {
            Console.WriteLine($"[{Name}] braces for defense\n");
            //Fighter braces, stops charging
            isBracing = true;
            isCharging = false;
        }

        public void Charge()
        {
            Console.WriteLine($"[{Name}] prepares their strength for the next attack\n");
            //Fighter charges, stops bracing
            isCharging = true;
            isBracing = false;
        }

        //the damage method to reduce health.
        public void Damage(int damage)
        {
            this.health = this.health - damage;
        }
    }
}