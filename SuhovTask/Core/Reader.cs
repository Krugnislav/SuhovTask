using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SuhovTask.Interfaces;

namespace SuhovTask.Core
{
    public class Reader: IReader
    {
        public Reader() { }
        public Int64 GetNumber() 
        {
            string numberAsString;
            Int64 number = 0;
            Console.Write("Input the number: ");
            numberAsString = Console.ReadLine();

            try
            {
                number = Convert.ToInt64(numberAsString);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Input string is not a sequence of digits.");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("The number cannot fit in an Int64.");
            }
            return number;
        }

    }
}
