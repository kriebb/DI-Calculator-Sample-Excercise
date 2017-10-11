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



        public void RegisterV1(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IOperationFactory, OperationFactory>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IOperation, MultiplyOperation>(Defines.Multiplication);
            unityContainer.RegisterType<IOperation, SubstractionOperation>(Defines.Substraction);
            unityContainer.RegisterType<IOperation, DivisionOperation>(Defines.Division);
            unityContainer.RegisterType<IOperation, SommationOperation>(Defines.Sum);

            unityContainer.RegisterType<ICalculator, OpenForExtensionCalculatorV1>(
                new ContainerControlledLifetimeManager());
        }
        public void RegisterV2(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<ICalculator, OpenForExtensionCalculatorV2>(
                new ContainerControlledLifetimeManager());

            unityContainer.RegisterType<IOperation, MultiplyOperation>(Defines.Multiplication);
            unityContainer.RegisterType<IOperation, SubstractionOperation>(Defines.Substraction);
            unityContainer.RegisterType<IOperation, DivisionOperation>(Defines.Division);
            unityContainer.RegisterType<IOperation, SommationOperation>(Defines.Sum);
        }
    }
}
