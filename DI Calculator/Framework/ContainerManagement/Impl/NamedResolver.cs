using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace DI_Calculator.Framework.ContainerManagement
{
    internal class NamedResolver : INamedResolver
    {
        private readonly IUnityContainer _unityContainer;

        public NamedResolver(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public T Resolve<T>(string name)
        {
            return _unityContainer.Resolve<T>(name);
        }
    }
}
