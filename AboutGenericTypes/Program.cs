using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutGenericTypes
{
    class Program
    {
        private static Random rand = new Random();

        static void Main(string[] args)
        {
            string s1 = "Svend";
            string s2 = "Knud";
            Swap(ref s1, ref s2);
            Console.WriteLine(s1);
            Console.WriteLine(s2);

            Test1();

            Test2();

            Par<int, int> p1 = new Par<int, int>(2, 3);
            Par<int, double> p2 = new Par<int, double>();
            p2.Arg1 = 23;
            p2.Arg2 = Math.PI;
            Par<string, Dice> p3 = new Par<string, Dice>("Red", new Dice());
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);

            Test3();

            Test4();

            Console.ReadLine();
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        static void Print<T>(T[] arr)
        {
            foreach (T t in arr) Console.Write(t + " ");
            Console.WriteLine();
        }
        
        // Generic method with implementation of Interface called IComparable, this interface defines only one method called CompareTo()
        // if the current object is less than the parameter, the method returns -1
        // if the current object is greater than the parameter, the method returns 1
        // otherwise, it returns 0
        static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int k = i;
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[j].CompareTo(arr[k]) < 0) k = j;
                if (i != k) Swap(ref arr[i], ref arr[k]);
            }
        }

        static void Test1()
        {
            int[] t = { 17, 13, 29, 3, 19, 11, 5, 2, 7, 23 };
            Print(t);
            Sort(t);
            Print(t);
        }

        static T[] Create<T>(int n) where T : new()
        {
            T[] arr = new T[n];
            for (int i = 0; i < arr.Length; i++) arr[i] = new T();
            return arr;
        }

        static void Test2()
        {
            Dice[] b = Create<Dice>(10);
            Print(b);
            Sort(b);
            Print(b);
        }

        static void Test3()
        {
            ISet<int> A = new Set<int>();
            A.Add(2);
            A.Add(3);
            A.Add(5);
            A.Add(7);
            A.Add(11);
            A.Add(13);
            A.Add(17);
            A.Add(19);
            A.Add(23);
            A.Add(29);
            ISet<int> B = new Set<int>();
            B.Add(2);
            B.Add(4);
            B.Add(8);
            B.Add(7);
            B.Add(16);
            Console.WriteLine(A);
            Console.WriteLine(B);
            ISet<int> C = A.Union(B);
            ISet<int> D = A.Difference(B);
            ISet<int> E = A.Intersection(B);
            Console.WriteLine(C);
            Console.WriteLine(D);
            Console.WriteLine(E);
            B.Remove(2);
            B.Remove(4);
            B.Remove(6);
            Console.WriteLine(B);
            for (int i = 0; i < 28; i++) B.Add(i);
            Console.WriteLine(B);
        }

        static void Test3Ex()
        {
            ISet<int> A = new Set<int>();
            try
            {
                for (int i = 0; i < 20; i++)
                {

                }
            }
            catch
            {
                Console.WriteLine("There war an error.");
            }
        }

        static void Test4()
        {
            int N = 10000;
            ISet<int> A = Create(N, 2 * N);
            ISet<int> B = Create(N, 2 * N);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ISet<int> C = A.Union(B);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Start();
            ISet<int> D = A.Intersection(B);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static ISet<int> Create(int n, int m)
        {
            Set<int> S = new Set<int>();
            while (n-- > 0) S.Add(rand.Next(m));
            return S;
        }
    }

    /// <summary>
    /// Dice class with IComparable 
    /// </summary>
    class Dice : IComparable<Dice>
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

        public override string ToString()
        {
            return "" + eyes;
        }

        public int CompareTo(Dice d)
        {
            return eyes < d.eyes ? -1 : eyes > d.eyes ? 1 : 0;
        }
    }

    /// <summary>
    /// Parameterized Types: types can be generic
    /// the following example has a type that represents a pair of objects
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    class Par<T1, T2>
    {
        private T1 arg1;
        private T2 arg2;

        public Par()
        {
        }

        public Par(T1 t1, T2 t2)
        {
            arg1 = t1;
            arg2 = t2;
        }

        public T1 Arg1
        {
            get { return arg1; }
            set { arg1 = value; }
        }

        public T2 Arg2
        {
            get { return arg2; }
            set { arg2 = value; }
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", Arg1.ToString(), Arg2.ToString());
        }
    }
 
    /// <summary>
    /// The class Set that implements the mathematical concept of a set.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISet<T>
    {
        int Count { get; }                  // know how many elements the set contains
        T this[int n] { get; }              // read the element in position n
        void Add(T elem);                   // add an element to the set
        void Remove(T elem);                // remove a particular element from the set
        bool Contains(T elem);              // ask whether a certain element is in the set
        ISet<T> Union(ISet<T> set);         // form the union of the two sets
        ISet<T> Intersection(ISet<T> set);  // form the intersection of two sets
        ISet<T> Difference(ISet<T> set);    // form the set difference of two sets
    }

    /// <summary>
    /// A class that implement the methods from the Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Set<T> : ISet<T>
    {
        private T[] elems = new T[10];
        private int count = 0;

        public int Count
        {
            get { return count; }
        }

        public T this[int n]
        {
            get { return elems[n]; }
        }

        public void Add(T elem)
        {
            if (IndexOf(elem) >= 0) throw new AddException();
            if (count == elems.Length) Expand();
            elems[count++] = elem;
        }

        public void Remove(T elem)
        {
            int n = IndexOf(elem);
            if (n < 0) throw new RemoveException();
            elems[n] = elems[--count];
        }

        public bool Contains(T elem)
        {
            return IndexOf(elem) >= 0;
        }

        public ISet<T> Union(ISet<T> set)
        {
            Set<T> tmp = new Set<T>();
            for (int i = 0; i < set.Count; i++) tmp.Add(set[i]);
            for (int i = 0; i < count; i++) if (!set.Contains(elems[i])) tmp.Add(elems[i]);
            return tmp;
        }

        public ISet<T> Intersection(ISet<T> set)
        {
            Set<T> tmp = new Set<T>();
            for (int i = 0; i < count; i++) if (set.Contains(elems[i])) tmp.Add(elems[i]);
            return tmp;
        }

        public ISet<T> Difference(ISet<T> set)
        {
            Set<T> tmp = new Set<T>();
            for (int i = 0; i < count; i++) if (!set.Contains(elems[i])) tmp.Add(elems[i]);
            return tmp;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            for (int i = 0; i < count; i++)
            {
                builder.Append(' ');
                builder.Append(elems[i]);
            }
            builder.Append("}");
            return builder.ToString();
        }

        private int IndexOf(T elem)
        {
            for (int i = 0; i < count; i++)
            {
                if (elems[i].Equals(elem)) return i;
            }
            return -1;
        }

        private void Expand()
        {
            T[] temp = new T[2 * elems.Length];
            for (int i = 0; i < count; i++)
            {
                temp[i] = elems[i];
            }
            elems = temp;
        }
    }

    /// <summary>
    /// Exception handling
    /// </summary>
    public class SetException : ApplicationException
    {
        public SetException(string message) : base (message)
        {
        }
    }

    public class AddException : SetException
    {
        public AddException() : base("The element already exists in the set and cannot be added")
        { }
    }

    public class RemoveException : SetException
    {
        public RemoveException() : base("The element is not found in the set and cannot be removed")
        { }
    }
}
