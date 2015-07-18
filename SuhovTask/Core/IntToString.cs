using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuhovTask.Core
{
    public static class IntToString
    {
        private static string[] units = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static string[] second_dozen = { "ten", "eleven", "twelve", "thirteen", "fFourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static string[] dozens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static string[] hundreds = { "hundred", "one hundred", "two hundreds", "three hundreds", "four hundreds", "five hundrets", "six hundreds", "seven hundreds", "eight hundreds", "nine  hundreds" };
        private static string[] thousands = { "thousand", "one thousand", "two thousands", "less than five thousands", "thousands" };
        private static string[] millionBillions = { "million", "billion" };
        private static string[] plural = { "less than five", "more than five" };

        public static string GetHundreds(int number)
        {
            var sb = new StringBuilder();
            if (number != 0)
            {
                sb.Append((Dictionary.Get(hundreds[number]) ?? Dictionary.Get(units[number]) + " " + Dictionary.Get(hundreds[0]) + (number > 1 ? Dictionary.Get(plural[0]) : "")) + " ");
            }

            return sb.ToString();
        }

        public static string GetDozens(int number)
        {
            var sb = new StringBuilder();
            if (number != 0)
            {
                sb.Append(Dictionary.Get(dozens[number - 2]) + " ");
            }
            return sb.ToString();
        }

        public static string GetSecondDozens(int number)
        {
            var sb = new StringBuilder();
            if (number != 0)
            {
                sb.Append(Dictionary.Get(second_dozen[number]) + "  ");
            }
            return sb.ToString();
        }

        public static string GetUnits(int number, int value)
        {
            var sb = new StringBuilder();

            if (number != 0) sb.Append(Dictionary.Get(units[number]) + " ");

            if (value > 0)
                sb.Append(GetOrders(number, value));

            return sb.ToString();
        }

        public static string GetThousands(int number)
        {
            var sb = new StringBuilder();

            if (number == 0)
            {
                sb.Append(Dictionary.Get(thousands[4]) ?? Dictionary.Get(thousands[0]) + Dictionary.Get(plural[0]));
            }
            if (number < 3)
            {
                sb.Append(Dictionary.Get(thousands[number]) ?? Dictionary.Get(units[number]) + " " + Dictionary.Get(thousands[0]) + (number > 1 ? Dictionary.Get(plural[0]) : ""));
            }
            else if (number < 5)
            {
                sb.Append(Dictionary.Get(units[number]) + " " + (Dictionary.Get(thousands[3]) ?? Dictionary.Get(thousands[0]) + Dictionary.Get(plural[0])));
            }
            else if (number > 5)
            {
                sb.Append(Dictionary.Get(units[number]) + " " + (Dictionary.Get(thousands[4]) ?? Dictionary.Get(thousands[0]) + Dictionary.Get(plural[0])));
            } 

            return sb.ToString();
        }

        public static string GetOrders(int number, int value)
        {
            var sb = new StringBuilder();

            sb.Append(Dictionary.Get(millionBillions[value - 2]));

            if (number > 1)
            {
                sb.Append(Dictionary.Get(number < 5 ? plural[0] : plural[1]));
            }

            return sb.ToString();
        }

        public static string GetZero()
        {
            return Dictionary.Get(units[0]);
        }
    }
}
