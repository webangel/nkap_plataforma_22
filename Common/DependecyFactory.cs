using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightInject;

namespace Common
{
    public class DependecyFactory
    {
        public static T GetInstance<T>()
        {
            return new LightInject.ServiceContainer()
                                  .GetInstance<T>();
        }
    }
}
