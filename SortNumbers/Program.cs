/// 1. User enter two numbers
/// 2. program will print the numbers in ascending order
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }

        static int Enter()
        {
            Console.Write("Enter an integer: ");
            string n1 = Console.ReadLine();
            return Convert.ToInt32(n1);
        }

        static void Sort1(int a, int b)
        {
            if (a > b)
            {
                int t = a;
                a = b;
                b = t;
            }
            Console.WriteLine("{0} {1}", a, b);
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }

        static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Sort numbers");
            Console.WriteLine("");
            Console.WriteLine("2. Exit");
            string result = Console.ReadLine();

            if(result == "1")
            {
                int n1 = Enter();
                int n2 = Enter();
                Sort1(n1, n2);
                return true;
            }
            else if(result == "2")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
