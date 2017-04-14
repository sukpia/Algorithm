using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutStaticMembers
{
    public static class Str
    {
        public static string Cut(string text, int width)
        {
            if (text.Length > width) return text.Substring(0, width);
            return text;
        }

        public static string FillRight(string text, int width, char ch)
        {
            StringBuilder builder = new StringBuilder(text);
            while (builder.Length < width) builder.Append(ch);
            return builder.ToString();
        }

        public static string FillLeft(string text, int width, char ch)
        {
            if (text.Length >= width) return text;
            StringBuilder builder = new StringBuilder(width - text.Length);
            for (int i = 0; i < builder.Capacity; i++) builder.Append(ch);
            return builder.ToString() + text;
        }

        public static string FillCenter(string text, int width, char ch)
        {
            return FillRight(FillLeft(text, text.Length + (width - text.Length) / 2, ch), width, ch);
        }
    }
}
