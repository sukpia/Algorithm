using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Test3();
            Console.ReadLine();
        }

        static void Test1()
        {
            Point p1;
            Point p2 = new Point(4, 5);
            p1.x = 2;
            p1.y = 3;
            Point p3 = p1;
            p3.y = 8;
            Show(p1);
            Show(p2);
            Show(p3);
            Console.WriteLine(p3.Length);
        }

        private static void Show(Point p)
        {
            Console.WriteLine(" ({0},{1}) ", p.x, p.y);
        }

        static void Test2()
        {
            Par p1;
            p1.d1 = new Dice();
            p1.d2 = new Dice();
            Console.WriteLine(p1);
            Par p2 = p1;
            Console.WriteLine(p2);
            p1.Throw();
            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }

        // A struct is a value type, and therefore can't be null.
        // However, it nullable like the simple type as shown below:
        static void Test3()
        {
            Nullable<Point> p = null;
            Console.WriteLine(": " + p);
            p = new Point(3.14, 1.41);
            Console.WriteLine(": " + p);
            Console.WriteLine(p.Value.Length);
            Point v = p.Value;
            v.x = 11;
            v.y = 13;
            Console.WriteLine(": " + p);
        }
    }

    struct Point
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double Length
        {
            get { return Math.Sqrt(x * x + y * y); }
        }

        public override string ToString()
        {
            return string.Format(" ({0}, {1}) ", x, y);
        }
    }

    class Dice
    {
        private static Random rand = new Random();
        private int eyes;

        public Dice()
        {
            Throw();
        }

        public int Eyes
        {
            get { return eyes; }
        }

        public void Throw()
        {
            eyes = rand.Next(1, 7);
        }
    }

    struct Par
    {
        public Dice d1;
        public Dice d2;

        public void Throw()
        {
            d1.Throw();
            d2.Throw();
        }

        public override string ToString()
        {
            return d1.Eyes + " " + d2.Eyes;
        }
    }
}
