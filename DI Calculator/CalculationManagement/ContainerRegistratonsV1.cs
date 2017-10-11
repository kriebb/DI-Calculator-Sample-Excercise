using DI_Calculator.CalculationManagement.Impl.OpenForExtension;
using DI_Calculator.CalculationManagement.Impl.OpenForExtension.Operations;
using DI_Calculator.Shared;
using Microsoft.Practices.Unity;

namespace DI_Calculator.CalculationManagement
{
    public class ContainerRegistratonsV1
    {


        public void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IOperationFactory, OperationFactory>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IOperation, MultiplyOperation>(Defines.Multiplication);
            unityContainer.RegisterType<IOperation, SubstractionOperation>(Defines.Substraction);
            unityContainer.RegisterType<IOperation, DivisionOperation>(Defines.Division);
            unityContainer.RegisterType<IOperation, SommationOperation>(Defines.Sum);

            unityContainer.RegisterType<ICalculator, OpenForExtensionCalculatorV1>(
                new ContainerControlledLifetimeManager());
        }

    }
}