using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hunter_X_Hunter_part_2
{
    class Program
    {

        static Fighter fighter1;
        static Fighter fighter2;
        static Random rnd = new Random();
        static Arena arena = new Arena();

        static void Main(string[] args)
        {
            //greet player
            Console.WriteLine("***  Welcome to the final round of the hunter exam  ***\n");
            GenerateFighters();
            Console.WriteLine($"Today's battle will take place between [{fighter1.Name}] and [{fighter2.Name}]\n\n");
            Thread.Sleep(2000);

            Console.WriteLine("Lets head to the arena\n");
            Thread.Sleep(1000);

            //Start the battle and receive the winner
            bool winner = arena.Battle(fighter1, fighter2);

            if (winner == true)
            {
                Console.WriteLine("Congratulations you pass the hunter exam!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You've been KOed better luck next year");
                Console.ReadLine();
            }
        }





        static void GenerateFighters()
        {
            //right now the player can only be Gon
            fighter1 = new Fighter("Gon");
            string f2name;

            //calculate probability between 1 and 100;
            int prob = rnd.Next(1, 101);
            if (prob > 0 && prob <= 5)
            {
                f2name = "Tompa";
            }
            else if (prob > 5 && prob <= 20)
            {
                f2name = "Hizoka";
            }
            else
            {
                f2name = "Hanzo";
            }

            //generate comp fighter
            fighter2 = new Fighter(f2name);
        }
    }
}
