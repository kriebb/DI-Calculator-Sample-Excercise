using DI_Calculator.CalculationManagement.Impl.OpenForExtension;
using DI_Calculator.CalculationManagement.Impl.OpenForExtension.Operations;
using DI_Calculator.Shared;
using Microsoft.Practices.Unity;

namespace DI_Calculator.CalculationManagement
{
    public class ContainerRegistratonsV2
    {

        public void Register(IUnityContainer unityContainer)
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