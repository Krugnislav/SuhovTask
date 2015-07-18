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
            else if (number == 0) return IntToString.GetZero();

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
            var numAsString = new StringBuilder();

            try 
            {
                numAsString.Append(IntToString.GetHundreds(intArray[2]));
            } catch(Exception e) {}

            try 
            {
                if (intArray[1] > 1)
                {
                    numAsString.Append(IntToString.GetDozens(intArray[1]));
                } 
                else if (intArray[1] == 1)
                {
                    numAsString.Append(IntToString.GetSecondDozens(intArray[0]));
                    secondDozen = true;
                }

            } catch(Exception e) {}

            try 
            {
                if ((intArray[0] != 0) || (!secondDozen))
                {
                    if (count == 1)
                        numAsString.Append(IntToString.GetThousands(intArray[0]));
                    else
                        numAsString.Append(IntToString.GetUnits(intArray[0], count));
                } 
                else
                {
                    if (count == 1)
                        numAsString.Append(IntToString.GetThousands(0));
                    else
                        numAsString.Append(IntToString.GetUnits(9, count));
                }
            }
            catch (Exception e) { }

            return numAsString.ToString();
        }


    }
}
