using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;
using System.Configuration;
using SuhovTask.Core;
using SuhovTask.LanguageFiles;

namespace SuhovTask
{
    class Program
    {
        ResourceManager res_man;    

        static void Main(string[] args)
        {
            string numberAsString;
            int number = 0;
            numberAsString = Console.ReadLine();

            try
            {
                number = Convert.ToInt32(numberAsString);
                string Text = res_man.GetString("MainForm_text", LocalConfiguration.Language);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Input string is not a sequence of digits.");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("The number cannot fit in an Int32.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.Write("The number is: {0}", number.ToString());
                Console.ReadLine();
            }

        }
    }
}
