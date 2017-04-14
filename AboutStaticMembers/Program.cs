using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutStaticMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Test2();
            Console.ReadLine();
        }

        static void Test1()
        {
            Console.WriteLine(Str.Cut("1234567890", 8));
            Console.WriteLine(Str.Cut("1234567890", 12));
        }

        static void Test2()
        {
            Console.WriteLine(Str.FillRight("abc", 10, 'x'));
            Console.WriteLine(Str.FillLeft("abc", 10, 'x'));
            Console.WriteLine(Str.FillCenter("abc", 10, 'x'));
        }
    }
}
