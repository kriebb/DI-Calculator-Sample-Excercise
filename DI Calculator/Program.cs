using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DI_Calculator.Bootstrap;
using DI_Calculator.CalculationManagement.Impl;
using DI_Calculator.DisplayManagement.Impl;
using ObscureWare.Console;

namespace DI_Calculator
{
    class Program
    {

        static void Main(string[] args)
        {
            //Oefening op Single Responsability gecombineerd met Manuele Injection
            //Indien nog niet gedaan bij het vorige voorbeeld, zorg ervoor dat de Displayer ook getest worden wat hij zal displayen.
            //Schrijf nu een test waarvan je het resultaat en niet of de methode gecalled wordt gaat testen.
            //Schrijf dan een test zodat je zeker bent dat de console methode e.g. WriteLine wordt opgeroepen met wat hij moet tonen.

            var operation1 = "+";

            var x1 = 4;
            var y1 = 3;

            var operation2 = "*";
            var x2 = 4;
            var y2 = 3;

            var console = new SystemConsole(new ConsoleController());

            var calculator = new SimpleCalculator();
            var displayer = new ResultDisplayer(console, new ResultFactory());
            var appStartup = new Startup(calculator, displayer);

            appStartup.Start(operation1, x1, y1);
            appStartup.Start(operation2, x2, y2);

        }





    }
}
