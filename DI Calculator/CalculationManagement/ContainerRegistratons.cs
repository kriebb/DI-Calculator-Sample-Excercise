using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI_Calculator.CalculationManagement.Impl.OpenForExtension;
using DI_Calculator.CalculationManagement.Impl.OpenForExtension.Operations;
using DI_Calculator.CalculationManagement.Impl.Simple;
using DI_Calculator.Shared;
using Microsoft.Practices.Unity;

namespace DI_Calculator.CalculationManagement
{
    public class ContainerRegistratons
    {
        public void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<ICalculator, SimpleCalculator>(new ContainerControlledLifetimeManager());
        }
        
    }
}
