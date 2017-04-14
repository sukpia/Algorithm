/// Abstract class is a class that can't be instantiated
/// You can't create objects of an abstract class
/// but abstract class can be base classes for other concrete classes
/// In this example, write a class that can represents a loan in a bank
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Amortisation table1 = new Amortisation(new SerialLoan(10000, 0.02, 10));
            Amortisation table2 = new Amortisation(new AnnuityLoan(10000, 0.02, 10));
            table1.Print();
            Console.WriteLine("\n");
            table2.Print();
            Console.ReadLine();
        }
    }

    public abstract class Loan
    {
        protected double principal;
        protected double rate;
        protected int periods;

        public Loan(double principal, double rate, int periods)
        {
            this.principal = principal;
            this.rate = rate;
            this.periods = periods;
        }

        public double Principal
        {
            get { return principal; }
        }

        public double Rate
        {
            get { return rate; }
        }

        public int Periods
        {
            get { return periods; }
        }

        public abstract double Payment(int n);
        public abstract double Interest(int n);
        public abstract double Repayment(int n);
        public abstract double Outstanding(int n);
    }

    public class SerialLoan : Loan
    {
        public SerialLoan(double principal, double rate, int periods) : base (principal, rate, periods)
        {

        }

        public override double Repayment(int n)
        {
            return principal / periods;
        }

        public override double Outstanding(int n)
        {
            return Repayment(0) * (periods - n);
        }

        public override double Interest(int n)
        {
            return Outstanding(n - 1) * rate;
        }

        public override double Payment(int n)
        {
            return Repayment(n) + Interest(n);
        }
    }

    public class AnnuityLoan : Loan
    {
        public AnnuityLoan(double principal, double rate, int periods) : base(principal, rate, periods)
        {

        }

        public override double Payment(int n)
        {
            return principal * rate / (1 - Math.Pow(1 + rate, -periods));
        }

        public override double Outstanding(int n)
        {
            return principal * Math.Pow(1 + rate, n) - Payment(0) * (Math.Pow(1 + rate, n) - 1) / rate;
        }

        public override double Interest(int n)
        {
            return Outstanding(n - 1) * rate;
        }

        public override double Repayment(int n)
        {
            return Payment(n) - Interest(n);
        }
    }

    public class Amortisation
    {
        private Loan loan;

        public Amortisation(Loan loan)
        {
            this.loan = loan;
        }

        public void Print()
        {
            Console.WriteLine("Principal: {0,10:F}", loan.Principal);
            Console.WriteLine("Rate of Interest: {0,10:F}", loan.Rate);
            Console.WriteLine("Number of periods: {0,10:D}\n", loan.Periods);
            Console.WriteLine("{0,7} {1,15} {2,15} {3,15} {4,15}", "Periods", "Payment", "Repayment", "Interest", "Outstanding");
            for (int n = 1; n < loan.Periods; n++)
            {
                Console.WriteLine("{0,7:D} {1,15:F} {2,15:F} {3,15:F} {4,15:F}", n, loan.Payment(n), loan.Repayment(n), loan.Interest(n), loan.Outstanding(n));
            }
        }
    }
}
