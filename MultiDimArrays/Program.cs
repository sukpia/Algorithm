using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimArrays
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
            char[,] t = new char[5, 4];
            char ch = 'A';
            for (int i = 0; i < t.GetLength(0); i++)
                for (int j = 0; j < t.GetLength(1); j++) t[i, j] = ch++;
            Print(t);
        }
        
        static void Test2()
        {
            char[,,] t = new char[3, 5, 4];
            char ch = 'A';
            for (int i = 0; i < t.GetLength(0); i++)
                for (int j = 0; j < t.GetLength(1); j++)
                    for (int k = 0; k < t.GetLength(2); k++) t[i, j, k] = ch++;
            Print(t);
        }

        static void Test3()
        {
            int[,] t = { { 2,3,5,7 }, { 11,13,17,19 }, { 23,29,31,37 } };
            Print(t);
        }

        static void Test4()
        {
            char[][] t = new char[4][];
            t[0] = new char[3];
            t[1] = new char[5];
            t[2] = new char[2];
            t[3] = new char[7];
            char ch = 'A';
            for (int i = 0; i < t.Length; i++)
                for (int j = 0; j < t[i].Length; j++) t[i][j] = ch++;
            Print(t);
        }

        static void Test5()
        {
            int[] t = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            //Array.Clear(t, 0, 5);
            Array.Reverse(t);
            foreach (int n in t) Console.WriteLine(n);
        }

        static void Test6()
        {
            int[] t = { 23, 7, 5, 11, 3, 17, 29, 2, 19, 13 };
            Array.Sort(t);
            foreach (int n in t) Console.WriteLine(n);
        }

        static void Print(char[,] t)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++) Console.Write("{0} ", t[i, j]);
                Console.WriteLine();
            }
        }

        static void Print(char[,,] t)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    for (int k = 0; k < t.GetLength(2); k++) Console.Write("{0} ", t[i, j, k]);
                    Console.WriteLine();
                }
                Console.WriteLine();
            } 
        }

        static void Print(int[,] t)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++) Console.Write("{0, 3:D} ", t[i, j]);
                Console.WriteLine();
            }
        }

        static void Print(char[][] t)
        {
            for (int i = 0; i < t.Length; i++)
            {
                for (int j = 0; j < t[i].Length; j++) Console.Write("{0} ", t[i][j]);
                Console.WriteLine();
            }
        }
    }
}
