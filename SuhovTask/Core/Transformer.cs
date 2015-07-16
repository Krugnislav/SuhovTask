using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SuhovTask.Interfaces;

namespace SuhovTask.Core
{
    public class Transformer: ITransformer
    {
        private readonly string[] units = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        private readonly string[] second_dozen = { "ten", "eleven", "twelve", "thirteen", "fFourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private readonly string[] dozens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private readonly string[] hundreds = { "hundred", "one hundred", "two hundreds", "three hundreds", "four hundreds", "five hundrets", "six hundreds", "seven hundreds", "eight hundreds", "nine  hundreds" };
        private readonly string[] thousands = { "thousand", "one thousand", "two thousands", "less than five thousands", "thousands" };
        private readonly string[] millionBillions = {"million", "billion"};
        private readonly string[] plural = { "less than five", "more than five" };

        public Transformer()
        {

        }
        private int[] GetIntArray(Int64 num, int divider)
        {
            List<int> listOfInts = new List<int>();

            while(num > 0)
            {
                listOfInts.Add(Convert.ToInt32(num % divider));
                num = num / divider;
            }

            return listOfInts.ToArray();
        }

        public string Transform(Int64 number)
        {
            if (number > 999999999999)
            {
                return "The number cannot be more than 999999999999.";

            }
            else if (number == 0) return Dictionary.Get(units[0]);

            int[] intArray = GetIntArray(number, 1000);

            List<string> num = new List<string>();

            for (int i = 0; i < intArray.Length; i++)
            {

                num.Add(GetStringFromNumber(intArray[i], i));
            }

            num.Reverse();

            string str = string.Join(" ", num);

            return str;
        }

        private string GetStringFromNumber(int number, int count)
        {
            int[] intArray = GetIntArray(number, 10);
            bool secondDozen = false;            
            string numAsString = null;

            try 
            {
                if (intArray[2] != 0)
                {
                    numAsString = (Dictionary.Get(hundreds[intArray[2]]) ?? Dictionary.Get(units[intArray[2]]) + " " + Dictionary.Get(hundreds[0]) + (intArray[2] > 1 ? Dictionary.Get(plural[0]) : "")) + " ";
                }

            } catch(Exception e) {}

            try 
            {
                if (intArray[1] > 1)
                {
                    numAsString = numAsString + Dictionary.Get(dozens[intArray[1] - 2]) + " ";
                } 
                else if (intArray[1] == 1)
                {
                    numAsString = numAsString + Dictionary.Get(second_dozen[intArray[0]]) + "  ";
                    secondDozen = true;
                }

            } catch(Exception e) {}

            try 
            {
                if (intArray[0] != 0)
                {
                    if ((count == 1))
                    {
                        if (intArray[0] < 3)
                        {                            
                            numAsString = numAsString + (Dictionary.Get(thousands[intArray[0]]) ?? Dictionary.Get(units[intArray[0]]) + " " + Dictionary.Get(thousands[0]) + (intArray[0] > 1 ? Dictionary.Get(plural[0]) : ""));
                        } else if (intArray[0] < 5)
                        {
                            numAsString = numAsString + Dictionary.Get(units[intArray[0]]) + " " + (Dictionary.Get(thousands[3]) ?? Dictionary.Get(thousands[0])+ Dictionary.Get(plural[0]));
                        }
                    }
                    else
                    {
                        numAsString = numAsString + Dictionary.Get(units[intArray[0]]);

                    }
                }
            }
            catch (Exception e) { }

            return numAsString;
        }


    }
}
