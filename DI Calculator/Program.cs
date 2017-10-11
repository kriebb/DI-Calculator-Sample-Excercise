using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DI_Calculator.Bootstrap;
using DI_Calculator.CalculationManagement;
using DI_Calculator.CalculationManagement.Impl.OpenForExtension;
using DI_Calculator.CalculationManagement.Impl.OpenForExtension.Operations;
using DI_Calculator.CalculationManagement.Impl.Simple;
using DI_Calculator.DisplayManagement;
using DI_Calculator.DisplayManagement.Impl;
using DI_Calculator.Shared;
using Microsoft.Practices.Unity;
using ObscureWare.Console;

namespace DI_Calculator
{
    class Program
    {
        public static string CalculationVersion { get; set; }

        static void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IConsole, SystemConsole>(new ContainerControlledLifetimeManager(), new InjectionConstructor(new ConsoleController()));
            unityContainer.RegisterType<IDisplayer, ResultDisplayer>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IOutputBuilderResult, ResultFactory>(new ContainerControlledLifetimeManager());

            unityContainer.RegisterType<ICalculator, SimpleCalculator>(new ContainerControlledLifetimeManager());

        }


        static void RegisterV1(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IOperationFactory, OperationFactory>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IOperation, MultiplyOperation>(Defines.Multiplication);
            unityContainer.RegisterType<IOperation, SubstractionOperation>(Defines.Substraction);
            unityContainer.RegisterType<IOperation, DivisionOperation>(Defines.Division);
            unityContainer.RegisterType<IOperation, SommationOperation>(Defines.Sum);

            unityContainer.RegisterType<ICalculator, OpenForExtensionCalculatorV1>(
                new ContainerControlledLifetimeManager());
        }
        static void RegisterV2(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<ICalculator, OpenForExtensionCalculatorV2>(
                new ContainerControlledLifetimeManager());

            unityContainer.RegisterType<IOperation, MultiplyOperation>(Defines.Multiplication);
            unityContainer.RegisterType<IOperation, SubstractionOperation>(Defines.Substraction);
            unityContainer.RegisterType<IOperation, DivisionOperation>(Defines.Division);
            unityContainer.RegisterType<IOperation, SommationOperation>(Defines.Sum);
        }

        static void RegisterVersionFactory(IUnityContainer container)
        {
            switch (CalculationVersion)
            {
                case DefinesVersion.V0:
                    break;

                case DefinesVersion.V1:
                    RegisterV1(container);
                    break;

                case DefinesVersion.V2:
                    RegisterV2(container);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Please set the featureFlag to V0, V1, V2");

            }
        }

        static void Main(string[] args)
        {
            //Refactor de register methode, zodanig dat die versie onafhankelijk zijn.
            //Nadeel van deze methode is wel dat je de childcontainer moet bewerken en je niet on the fly kunt switchen van functionaliteit.
            //Maar soms hoeft dat ook niet....
            //Zorg ervoor dat gebruiker een bericht krijgt van geen ondersteuning.

            CalculationVersion = "V0";

            var operandSum = "+";
            var xSum = 4;
            var ySum = 3;

            var operandMultiply = "*";
            var xMultiply = 4;
            var yMultiply = 3;

            var operandSubstraction = "-";
            var xSubstraction = 4;
            var ySubstraction = 3;

            var operandDivision = "/";
            var xDivision = 3;
            var yDivision = 4;

            using (var unityContainer = new UnityContainer())
            {
                Register(unityContainer);

                //You can also resolve here some stuff... This is the main.
                //You can put this in a loop....
                using (var childContainer = unityContainer.CreateChildContainer())
                {
                    RegisterVersionFactory(childContainer);

                    //You can also register here some stuff if you want to override
                    var appStartup = childContainer.Resolve<Startup>();

                    appStartup.Start(operandSum, xSum, ySum);
                    appStartup.Start(operandMultiply, xMultiply, yMultiply);
                    appStartup.Start(operandSubstraction, xSubstraction, ySubstraction);
                    appStartup.Start(operandDivision, xDivision, yDivision);
                }
            }
        }

    }
}
