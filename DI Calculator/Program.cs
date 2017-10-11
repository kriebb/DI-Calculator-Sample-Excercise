using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DI_Calculator.Bootstrap;
using DI_Calculator.CalculationManagement;
using DI_Calculator.CalculationManagement.Impl;
using DI_Calculator.DisplayManagement;
using DI_Calculator.DisplayManagement.Impl;
using Microsoft.Practices.Unity;
using ObscureWare.Console;

namespace DI_Calculator
{
    class Program
    {

        static void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IConsole, SystemConsole>(new ContainerControlledLifetimeManager(), new InjectionConstructor(new ConsoleController()));
            unityContainer.RegisterType<IDisplayer, ResultDisplayer>(new ContainerControlledLifetimeManager());
            //unityContainer.RegisterType<ICalculator, SimpleCalculator>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<ICalculator, OpenForExtensionCalculator>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IOperationFactory, OperationFactory>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IOutputBuilderResult, ResultFactory>(new ContainerControlledLifetimeManager());
        }
        static void Main(string[] args)
        {
            //We gaan aan de advanced calculator de subtraction and the division operation toevoegen
            //Kuis de openforextension calculator op (dead code...) van de vorige commit
            //Voer twee extra berekeningen uit, namelijk 4-3 en 3/4
            //We ondersteunen geen restberekeningen.


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
