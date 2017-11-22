using System;
using System.Text;

namespace CodeKata.FizzBuzz
{
    public class Class1
    {
        public static string FizzBuzzStringHolen(int input)
        {

            if (input % 15 == 0)
            {
                return "FizzBuzz";
            }

            if (input % 3 == 0)
            {
                return "Fizz";
            }

            if (input % 5 == 0)
            {
                return "Buzz";
            }

            return FizzBuzzContoint3oder5StringHolen(input);
        }

        private static string FizzBuzzContoint3oder5StringHolen(int input)
        {
            var wert = input.ToString();

            if (wert.Contains("3"))
            {
                wert = "Fizz";
            }

            if (wert.Contains("5"))
            {
                return "Buzz";
            }

            return wert;
        }

        public static string Ausgabe1Bis100()
        {
            var uebersetzteStringBuilder = new StringBuilder();
            for (int input = 1; input <= 100; input++)
            {
                uebersetzteStringBuilder.Append(FizzBuzzStringHolen(input));
                uebersetzteStringBuilder.Append(" ");
            }

            return uebersetzteStringBuilder.ToString(0, uebersetzteStringBuilder.Length - 1);
        }
    }
}