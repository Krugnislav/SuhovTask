using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SuhovTask.Interfaces;

namespace SuhovTask.Core
{
    class Writer: IWriter
    {
        public Writer()
        {

        }

        public void Write(string number) {
            Console.Write("The number is: {0}", number);
            Console.ReadLine();
        }

    }
}
