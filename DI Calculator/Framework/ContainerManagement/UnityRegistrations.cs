using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI_Calculator.CalculationManagement;
using DI_Calculator.CalculationManagement.Impl.Simple;
using Microsoft.Practices.Unity;

namespace DI_Calculator.Framework.ContainerManagement
{
    public class ContainerRegistrations
    {
        public void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<INamedResolver, NamedResolver>(new ContainerControlledLifetimeManager());
        }

    }
}
