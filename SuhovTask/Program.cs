using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;
using System.Configuration;

using Ninject;

using SuhovTask.Interfaces;
using SuhovTask.Core;
using System.Reflection;

namespace SuhovTask
{
    class Program
    {

        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IReader reader = kernel.Get<IReader>();
            IWriter writer = kernel.Get<IWriter>();
            ITransformer transformer = kernel.Get<ITransformer>();

            while (true)
                writer.Write(transformer.Transform(reader.GetNumber()));
        }
    }
}
