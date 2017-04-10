/// Exam23 - Design of Classes using Yatzy program
/// 1. Write a class for Dice
/// 2. Write a class for Cup ( contains 5 dices)
/// 3. Write a class for Game (actual game that has a cup and a method that carries out the game
/// 4. Main program logic
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignOfClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(5);
            game.Play();
        }
    }

    public class Dice
    {
        private static Random rand = new Random();
        private int eyes;

        public Dice()
        {
            Throw ();
        }

        public void Throw()
        {
            eyes = rand.Next(1, 7);
        }

        public int Eyes
        {
            get { return eyes; }
        }

        public override string ToString()
        {
            return "" + eyes;
        }
    }

    public class Cup
    {
        private Dice[] dice;

        public Cup(int n)
        {
            dice = new Dice[n];
            for (int i = 0; i < n; i++)
            {
                dice[i] = new Dice();
            }
        }

        public int Count
        {
            get { return dice.Length; }
        }

        public Dice this[int i]
        {
            get { return dice[i]; }
        }

        public virtual void Toss()
        {
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i].Throw();
            }
        }

        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < dice.Length; i++)
            {
                if (i > 0) text += " ";
                text += dice[i].Eyes;
            }
            return text;
        }
    }

    public class Game
    {
        private Cup cup;

        public Game(int n)
        {
            cup = new Cup(n);
        }

        public void Play()
        {
            int count = 0;
            do
            {
                cup.Toss();
                ++count;
                Console.WriteLine(cup);
            } while (!Yatzy());
            Console.WriteLine("You've got Yatzy after {0} attaempts", count);
            Console.ReadLine();
        }

        private bool Yatzy()
        {
            for (int i = 0; i < cup.Count; i++)
            {
                if (cup[i].Eyes != cup[0].Eyes) return false;
            }
            return true;
        }
    }
}
