using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;
using Ninject.Modules;
using SuhovTask.Interfaces;
using SuhovTask.Core;

namespace SuhovTask
{
    public class Bindings : NinjectModule
    {
        public override void Load()
            {
                Bind<IReader>().To<Reader>();
                Bind<IWriter>().To<Writer>();
                Bind<ITransformer>().To<Transformer>();
            }
    }
}
