using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        //end contstructor



        //the damage method to reduce health.
        public void Damage(int damage)
        {
            this.health = this.health - damage;
        }
    }
}
