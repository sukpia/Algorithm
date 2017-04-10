using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Coin c1 = new Coin();
            Coin c2 = new Coin();

            do
            {
                c1.Throw();
                c2.Throw();
                Console.WriteLine(c1.Value + " " + c2.Value);
            } while (c1.Value != 'H' || c2.Value != 'H');
            Console.ReadLine();
        }
    }

    // Exam 22 - Classes
    public class Coin
    {
        private static Random rand = new Random();
        private char value;
        //public char value { get; }

        public Coin()
        {
            Throw();
        }

        public char Value
        {
            get { return value; }
        }

        public void Throw()
        {
            value = (rand.Next(2) == 0) ? 'H' : 'T';
        }

        public override string ToString()
        {
            return "" + value;
        }
    }
}
