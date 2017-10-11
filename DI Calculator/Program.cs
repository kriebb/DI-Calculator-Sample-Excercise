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
            switch (CalculationVersion)
            {
                case "V0":
                    unityContainer.RegisterType<ICalculator, SimpleCalculator>(new ContainerControlledLifetimeManager());

                    break;
                case "V1":
                    unityContainer.RegisterType<ICalculator, OpenForExtensionCalculatorV1>(new ContainerControlledLifetimeManager());

                    break;
                case "V2":
                    unityContainer.RegisterType<ICalculator, OpenForExtensionCalculatorV2>(new ContainerControlledLifetimeManager());

                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{nameof(CalculationVersion)} only supports V0 or V1 or V2. It was {CalculationVersion}");
            }
            unityContainer.RegisterType<IOperationFactory, OperationFactory>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IOperation, MultiplyOperation>(Defines.Multiplication);
            unityContainer.RegisterType<IOperation, SubstractionOperation>(Defines.Substraction);
            unityContainer.RegisterType<IOperation, DivisionOperation>(Defines.Division);
            unityContainer.RegisterType<IOperation, SommationOperation>(Defines.Sum);

            unityContainer.RegisterType<IOutputBuilderResult, ResultFactory>(new ContainerControlledLifetimeManager());
        }

        static void Main(string[] args)
        {
            //Vorige oefening werkt niet. De IOperations zijn niet geregistreerd!
            //Fix: de naam van één de operations. 
            //Hoe konden we dit tegengaan ? => Testing
            //Verander het gebruik van de OperationFactory, ook door de Defines te gebruiken (properdere code...))


            CalculationVersion = "V2";

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
