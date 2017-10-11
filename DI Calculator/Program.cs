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
            unityContainer.RegisterType<ICalculator, SimpleCalculator>(new ContainerControlledLifetimeManager());
        }
        static void Main(string[] args)
        {
            //Verwijderen van oude referentie Unity (foutje bij setup by me).
            //Toevoegen van unity op project DI Calculator
            //Splits het gebruik van de container op in twee delen:
            //-Registraties
            //-Resolving
            //Gebruik die twee zaken nooit door elkaar.
            //Werk altijld met een child container
            //In een childcontainer kan je ook je registraties overschrijven.
            //Vervang de manuele injectie door een resolve op de container.
            //Registreer nog niet de interface IOutputBuilderResult met de gekozen implementatie
            //Run

            var operation1 = "+";

            var x1 = 4;
            var y1 = 3;

            var operation2 = "*";
            var x2 = 4;
            var y2 = 3;

            using (var unityContainer = new UnityContainer())
            {
                Register(unityContainer);

                //You can also resolve here some stuff... This is the main.
                //You can put this in a loop....
                using (var childContainer = unityContainer.CreateChildContainer())
                {
                    //You can also register here some stuff if you want to override
                    var appStartup = childContainer.Resolve<Startup>();

                    appStartup.Start(operation1, x1, y1);
                    appStartup.Start(operation2, x2, y2);
                }
            }
        }





    }
}
