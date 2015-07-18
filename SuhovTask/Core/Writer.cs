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

        public void Write(string number, string system) {
            Console.Write("{0}: {1} {2} {3} {4}", Dictionary.Get("Result"), number, Dictionary.Get("in"), Dictionary.Get(system), Dictionary.Get("system"));
            Console.ReadLine();
        }

    }
}
