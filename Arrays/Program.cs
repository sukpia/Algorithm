using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            bool displayMenu = true;

            while(displayMenu)
            {
                displayMenu = MainMenu();
            }
           
        }

        static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Play Yatzy");
            Console.WriteLine("2. Play Craps");
            Console.WriteLine("3. Exit");
            string result = Console.ReadLine();

            // Exam 20: Play Yatzy - a program to simulate where you throw 5 cubes until they show the same value
            if (result == "1")
            {
                int[] beaker = new int[5];
                Yatzy(beaker);
                return true;
            }
            // Exam 21: Play Craps - a program that simulates a simple dice game called craps.
            else if (result == "2")
            {
                Craps();
                return true;
            }
            else if (result == "3")
            {
                return false;
            }
            else
                return true;
        }

        static void Craps()
        {
            if (playCraps())
                Console.WriteLine("Player has won...");
            else
                Console.WriteLine("The house has won...");
            Console.ReadLine();
        }

        static bool playCraps()
        {
            int[] beaker = new int[2];
            int point = Throw(beaker);
            if (point == 7 || point == 11) return true;
            if (point == 2 || point == 3 || point == 12) return false;
            int sum = Throw(beaker);
            while (sum != 7 && sum != point) sum = Throw(beaker);
            return sum == point;
        }

        static void Yatzy(int[] beaker)
        {
            int count = 0;
            do
            {
                Cast(beaker);
                Show(beaker);
                count++;
            } while (!Equals(beaker));
            Console.WriteLine("You've got Yatzy after {0} attempts!", count);
            Console.ReadLine();
        }

        static void Cast(int[] beaker)
        {
            for (int i = 0; i < beaker.Length; i++)
            {
                beaker[i] = rand.Next(1, 7);
            }
        }

        static void Show(int[] beaker)
        {
            Console.Write("[ ");
            for (int i = 0; i < beaker.Length; i++)
            {
                Console.Write("{0} ", beaker[i]);
            }
            Console.WriteLine(" ]");
        }

        static bool Equals(int[] beaker)
        {
            for (int i = 0; i < beaker.Length; i++)
            {
                if (beaker[i] != beaker[0])
                    return false;
            }
            return true;
        }

        static int Throw(int[] beaker)
        {
            Cast(beaker);
            Show(beaker);
            return Sum(beaker);
        }

        static int Sum(int[] beaker)
        {
            int sum = 0;
            for (int i = 0; i < beaker.Length; i++)
            {
                sum += beaker[i];
            }
            return sum;
        }
    }
}
