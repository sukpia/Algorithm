using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(2, 3);
            //Mul(p, 2);
            Console.WriteLine(p);
            Mul2(p, 2);
            Console.WriteLine(p);
            Test2();
            Test3();
            Test4();
            Test5();
            Test6();
            Console.ReadLine();
        }

        /// <summary>
        /// Function Overriding - a class may have multiple methods with the same name
        /// as long as they have different parameters, either in terms of number or types.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Max(int a, int b)
        {
            return a < b ? b : a;
        }
        static double Max(double a, double b)
        {
            return a < b ? b : a;
        }
        static int Max(int a, int b, int c)
        {
            return Max(Max(a, b), Max(b, c));
        }

        /// <summary>
        /// PARAMETERS - value parameters, reference parameters, out-parameters, Default parameters, Variable numbers of parameters
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(int a, int b)
        {
            int t = a;
            a = b;
            b = t;
        }
        // Using Reference Parameters
        public static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
        static void Test2()
        {
            int t1 = 2;
            int t2 = 3;
            Swap(t1, t2);
            Console.WriteLine("Using Value Parameters: {0} {1}", t1, t2);
        }
        static void Test3()
        {
            int t1 = 2;
            int t2 = 3;
            Swap(ref t1, ref t2);
            Console.WriteLine("Using Reference Parameter: {0} {1}", t1, t2);
        }
        static void Mul(Point p, int t)
        {
            p.X *= t;
            p.Y *= t;
        }
        static void Mul2(Point p, int t)
        {
            p = new AboutMethods.Point(p.X, p.Y);
            p.X *= t;
            p.Y *= t;
        }
        // Using Out Parameters
        static void Points2(int x1, int y1, int x2, int y2, out Point p1, out Point p2)
        {
            p1 = new Point(x1, y1);
            p2 = new Point(x2, y2);
        }
        static void Test4()
        {
            Point p1;
            Point p2;
            Points2(2, 5, 7, 3, out p1, out p2);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
        // Using Default Parameters
        static double Calculate(double price, int units = 1, double discount = 5)
        {
            return price * units * (100 - discount) / 100;
        }
        static void Test5()
        {
            Console.WriteLine(Calculate(20));
            Console.WriteLine(Calculate(20, 5));
            Console.WriteLine(Calculate(20, 10));
        }
        static string Concat(params string[] text)
        {
            if (text.Length == 0) return "";
            string temp = text[0];
            for (int i = 0; i < text.Length; i++)
            {
                temp += " " + text[i];
            }
            return temp;
        }
        static void Test6()
        {
            Console.WriteLine(Concat("One", "Two", "Three"));
            Console.WriteLine(Concat("One"));
            Console.WriteLine(Concat());
            Console.WriteLine(Concat("One", "Two", "Three", "Four", "Five"));
        }
    }

    /// <summary>
    /// The idea of PROPERTY
    /// </summary>
    class Point
    {
        private int x;
        private int y;
        
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", x, y);
        }
    }
}
