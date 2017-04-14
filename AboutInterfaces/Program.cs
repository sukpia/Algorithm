using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
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
        public override int Value
        {
            get { return 50; }
        }
    }
}
