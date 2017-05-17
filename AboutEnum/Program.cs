using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutEnum
{
    class Program
    {
        public enum Ugedag : byte
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
            Error = 10
        }

        static void Main(string[] args)
        {
            Test1();
            Console.ReadLine();
        }

        static void Test1()
        {
            Ugedag dag;
            Console.Write(" (Mo, Tu, We, Th, Fr, Sa, Su)? ");
            string text = Console.ReadLine();
            switch(text)
            {
                case "Mo":
                    dag = Ugedag.Monday; break;
                case "Tu":
                    dag = Ugedag.Tuesday; break;
                case "We":
                    dag = Ugedag.Wednesday; break;
                case "Th":
                    dag = Ugedag.Thursday; break;
                case "Fr":
                    dag = Ugedag.Friday; break;
                case "Sa":
                    dag = Ugedag.Saturday; break;
                case "Su":
                    dag = Ugedag.Sunday; break;
                default:
                    dag = Ugedag.Error; break;
            }
            Console.WriteLine(dag);
        }
    }
}
