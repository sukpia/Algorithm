using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nTest1 Result:");
            Test1();
            Console.WriteLine("\nTest2 Result:");
            Test2();
            Console.ReadLine();
        }

        static void Test2()
        {
            Consultant c = new Consultant("Gudrun", "Madsen", 2000, 10);
            c.Sale = 30000;
            Print(c);
        }

        static void Test1()
        {
            Director d = new Director("Olga", "Jensen", 8000);
            Bookkeeper b = new Bookkeeper("Karlo", "Hansen", 5000);
            Print(d);
            Print(b);
        }

        static void Print(Employee e)
        {
            Console.WriteLine(e);
            Console.WriteLine("Monthly: {0}", e.Monthly);
            Console.WriteLine("{0}, {1}", e.LastName, e.FirstName);
        }
    }

    public class Person
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }

    public class Employee : Person
    {
        private string position;
        protected int monthly; // use protected so we can referenc it in derived class Consultant

        public Employee (string firstName, string lastName, string position, int monthly) : base(firstName, lastName)
        {
            this.position = position;
            this.monthly = monthly;
        }

        public string Position
        {
            get { return position; }
        }
        // added 'virtual' so we can override in derived class Consultant
        public virtual int Monthly
        {
            get { return monthly; }
        }

        public override string ToString()
        {
            return base.ToString() +"\n" + position;
        }
    }
    // added 'sealed' so this class can't be inherited
    public sealed class Director : Employee
    {
        public Director(string firstName, string lastName, int monthly) : base(firstName,lastName,"Director",monthly)
        {

        }
    }

    public class Bookkeeper : Employee
    {
        public Bookkeeper(string firstName, string lastName, int monthly) : base(firstName, lastName, "Bookkeeper", monthly)
        {

        }
    }

    public class Consultant : Employee
    {
        private double commission;
        private double sale;

        public Consultant(string firstName, string lastName, int monthly, double commission) : base(firstName, lastName, "Consultant", monthly)
        {
            this.commission = commission;
        }

        public double Commission
        {
            get { return commission; }
        }

        public double Sale
        {
            get { return sale; }
            set { sale = value; }
        }

        public override int Monthly
        {
            get { return monthly + (int)(sale * commission / 100); }
        }
    }
}
