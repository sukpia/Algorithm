using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutInterfaces
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            IPurse purse = new Purse(10);
            Init(purse);
            Console.WriteLine(purse.Value());
            for (int i = 0; i < 20; i++)
            {
                Buy(purse, Create());
            }
            Console.WriteLine(purse.Value());
            Console.ReadLine();
        }

        static void Buy(IPurse purse, IBankNote note)
        {
            if (purse.Has(note))
            {
                purse.Pay(note.Value);
                Console.WriteLine("Bought for {0} crones", note.Value);
            }
            else
                Console.WriteLine("Does not have a " + note);
        }

        static void Init(IPurse purse)
        {
            while (!purse.IsFull()) purse.Put(Create());
        }

        static IBankNote Create()
        {
            switch (rand.Next(15))
            {
                case 0: return new BankNote1000();
                case 1:
                case 2: return new BankNote500();
                case 3:
                case 4:
                case 5: return new BankNote200();
                case 6:
                case 7:
                case 8:
                case 9: return new BankNote100();
                default: return new BankNote50();
            }
        }
    }

    public interface IBankNote
    {
        int Value { get; }
    }

    public abstract class BankNote : IBankNote
    {
        public abstract int Value { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is IBankNote)) return false;
            return ((IBankNote)obj).Value == Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public override string ToString()
        {
            return Value + " Danish Crowns";
        }
    }

    public class BankNote50 : BankNote
    {
        public override int Value { get { return 50; }}
    }

    public class BankNote100 : BankNote
    {
        public override int Value { get { return 100; } }
    }

    public class BankNote200 : BankNote
    {
        public override int Value { get { return 200; } }
    }

    public class BankNote500 : BankNote
    {
        public override int Value { get { return 500; } }
    }

    public class BankNote1000 : BankNote
    {
        public override int Value { get { return 1000; } }
    }

    public interface IPurse
    {
        bool Put(IBankNote note);
        bool IsEmpty();
        bool IsFull();
        bool Has(IBankNote note);
        IBankNote Pay(int value);
        int Value();
    }

    public class Purse : IPurse
    {
        private IBankNote[] list;
        private int count;

        public Purse(int size)
        {
            list = new IBankNote[size];
        }

        public bool Put(IBankNote note)
        {
            if (count >= list.Length) return false;
            list[count++] = note;
            return true;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool IsFull()
        {
            return count == list.Length;
        }

        public bool Has(IBankNote note)
        {
            for (int i = 0; i < count; i++)
            {
                if (list[i].Equals(note)) return true;
            }
            return false;
        }

        public IBankNote Pay(int value)
        {
            for (int i = 0; i < count; i++)
            {
                if(list[i].Value == value)
                {
                    IBankNote note = list[i];
                    list[i] = list[--count];
                    return note;
                }
            }
            return null;
        }

        public int Value()
        {
            int sum = 0;
            for (int i = 0; i < count; i++) sum += list[i].Value;
            return sum;
        }
    }
}
