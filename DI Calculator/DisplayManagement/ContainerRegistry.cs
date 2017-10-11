using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI_Calculator.DisplayManagement.Impl;
using Microsoft.Practices.Unity;
using ObscureWare.Console;

namespace DI_Calculator.DisplayManagement
{
    public class ContainerRegistratons
    {
        public void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IConsole, SystemConsole>(new ContainerControlledLifetimeManager(), new InjectionConstructor(new ConsoleController()));
            unityContainer.RegisterType<IDisplayer, ResultDisplayer>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IOutputBuilderResult, ResultFactory>(new ContainerControlledLifetimeManager());
        }
    }
}
