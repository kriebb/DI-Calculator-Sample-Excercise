using DI_Calculator.CalculationManagement.Impl.OpenForExtension;
using DI_Calculator.CalculationManagement.Impl.OpenForExtension.Operations;
using DI_Calculator.Framework.InterceptionManagement;
using DI_Calculator.Shared;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace DI_Calculator.CalculationManagement
{
    public class ContainerRegistratonsV3
    {
        public void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<ICalculator, OpenForExtensionCalculatorV3> (
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>());
            unityContainer.RegisterType<IOperation, MultiplyOperation>(Defines.Multiplication);
            unityContainer.RegisterType<IOperation, SubstractionOperation>(Defines.Substraction);
            unityContainer.RegisterType<IOperation, DivisionOperation>(Defines.Division);
            unityContainer.RegisterType<IOperation, SommationOperation>(Defines.Sum);

            unityContainer.RegisterType<IKeyInputMapper, KeyInputMapper>(new ContainerControlledLifetimeManager());
        }
    }
}