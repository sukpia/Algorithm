using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Console.WriteLine(text.ToLower());
            Console.WriteLine(text);
            Console.WriteLine(text[3]);
            Console.WriteLine(text.Length);
            Console.WriteLine(text.Substring(3, 7));
            Console.WriteLine(text.Substring(12));
            Console.WriteLine(text.IndexOf("KLMN"));
            Console.WriteLine(text.IndexOf("KMLN"));
            Console.WriteLine(text.Substring(3, 7).CompareTo("DEFGHIJ"));
            Console.WriteLine(string.Compare(text, 9, "1234567891234jklmnopq56789", 13, 8, true));
            string text1 = "Peter";
            string text2 = "Anders";
            Console.WriteLine(string.Compare(text1, text2));
            Console.WriteLine(string.Compare(text2, text1));

            string line = Enter();
            if (isPalindrome(line.ToLower()))
                Console.WriteLine("\"" + line + "\"" + " is Palindrome");
            else
                Console.WriteLine("\"" + line + "\"" + " is NOT Palindrome");

            Console.ReadLine();

        }

        static bool isPalindrome(string text)
        {
            for (int i = 0, j = text.Length - 1; i < j;)
            {
                if(!charOK(text[i]) && !charOK(text[j]))
                {
                    ++i;
                    --j;
                }
                else if(!charOK(text[i]))
                {
                    ++i;
                }
                else if(!charOK(text[j]))
                {
                    --j;
                }
                else if(text[i] != text[j])
                {
                    return false;
                }
                else
                {
                    ++i;
                    --j;
                }
            }
            return true;
        }

        static bool charOK (char ch)
        {
            return (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9');
        }

        static string Enter()
        {
            Console.Write("? ");
            string text = Console.ReadLine();
            if (text.Length == 0) Environment.Exit(0);
            return text;
        }
    }
}
