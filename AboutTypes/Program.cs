using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutTypes
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            Test7();
            Console.ReadLine();
        }

        static void Test1()
        {
            //for (char c = ' '; c <= 255; c++) Console.WriteLine("{0} {1, 4:D}", c, (int)c);
            for (char c = ' '; c <= 255; c++) Console.Write("{0}({1}) ", c, (int)c);
        }

        static void Test2()
        {
            Console.WriteLine("sbyte  {0, 25:D} {1, 25:D}", sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine("byte   {0, 25:D} {1, 25:D}", byte.MinValue, byte.MaxValue);
            Console.WriteLine("short  {0, 25:D} {1, 25:D}", short.MinValue, short.MaxValue);
            Console.WriteLine("ushort {0, 25:D} {1, 25:D}", ushort.MinValue, ushort.MaxValue);
            Console.WriteLine("int    {0, 25:D} {1, 25:D}", int.MinValue, int.MaxValue);
            Console.WriteLine("uint   {0, 25:D} {1, 25:D}", uint.MinValue, uint.MaxValue);
            Console.WriteLine("long   {0, 25:D} {1, 25:D}", long.MinValue, long.MaxValue);
            Console.WriteLine("ulong  {0, 25:D} {1, 25:D}", ulong.MinValue, ulong.MaxValue);
        }

        // You can copy a smaller type into a larger type
        static void Test3()
        {
            sbyte b1 = 2;
            //byte b2 = b1; this will give error because you try to copy an integer which maybe negative in a variable can only contain non-negative numbers
            byte b2 = (byte)b1; // it will be fine if use casting
            int n = 2;
            //short s = n; this will give error because int is larger type
            short s = (short)n;
            long t = n; // this is fine because long is larger type 
        }

        static void Test4()
        {
            int a = 0x1abc23; // possibility of statements that with integers as hexadecimal digits
            Console.WriteLine(a);
            Console.WriteLine(Math.Pow(3.14, 50)); //that results 7.02234890660125 * 10^24, means double works approx. 15 significant digits.
            double x = 1234.678E+20; // you can also use exp. notation for a constant
            Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine("float {0, 30:E20} {1, 30:E20}", float.MinValue, float.MaxValue);
            Console.WriteLine(float.Epsilon); // constant Epsilon indicates the smallest positive number
            Console.WriteLine("double {0, 30:E20} {1, 30:E20}", double.MinValue, double.MaxValue);
            Console.WriteLine(double.Epsilon);
            Console.WriteLine(double.PositiveInfinity);
            Console.WriteLine(double.NegativeInfinity);
            Console.WriteLine(double.NaN); // means a value that does not represent a number
        }

        static void Test5()
        {
            Console.WriteLine(decimal.MinValue);
            Console.WriteLine(decimal.MaxValue);
            Console.WriteLine(decimal.Zero);
            Console.WriteLine(decimal.One);
            Console.WriteLine(decimal.MinusOne);
            decimal x = 2;
            Console.WriteLine(Sqrt(x)); // class Math is not implemented for variables of type decimal, you have to write the function
        }

        static decimal Sqrt(decimal x)
        {
            decimal y = x;
            while (true)
            {
                decimal v = y + x / y;
                decimal z = v / 2;
                if (Math.Abs(y - z) <= decimal.Zero) break;
                y = z;
            }
            return y;
        }

        // In general, the simple types are unchecked. That is, they are not tested for overflow if a value is too large.
        static void Test6()
        {
            // that results -557712591, which is not correct
            //int a = 1234567;
            //int b = 1234567;
            //Console.WriteLine(a * b);

            // This can be fixed by the following
            // the program will stop with an error message
            checked
            {
                int a = 1234567;
                int b = 1234567;
                Console.WriteLine(a * b);
            }
        }

        // Value type can be null with the following syntax (by adding ?)
        // operator ??, means the value is the expression after ?? if the value before is null
        static void Test7()
        {
            int a = 0;
            int? b = null;
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            b = 3;
            Console.WriteLine("b = " + b);
            int?[] t = new int?[5];
            for (int i = 0; i < t.Length; i++) t[i] = Number();
            Print(t);
            for (int i = 0; i < t.Length; i++) t[i] = Number() ?? 0;
            Print(t);
        }

        static void Print(int?[] t)
        {
            foreach (int? n in t) Console.Write("{0, -3}|", n);
            Console.WriteLine();
        }

        static int? Number()
        {
            if (rand.Next(2) == 1) return rand.Next(1, 10);
            return null;
        }
    }
}
