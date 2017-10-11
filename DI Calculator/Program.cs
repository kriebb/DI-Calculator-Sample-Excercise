using System;
using System.Threading;
using DI_Calculator.Bootstrap;
using DI_Calculator.CalculationManagement;
using DI_Calculator.DisplayManagement;
using DI_Calculator.Framework.SettingsManagement;
using DI_Calculator.Shared;
using Microsoft.Practices.Unity;


namespace DI_Calculator
{
        class Program
    {
        public static string CalculationVersion { get; set; }


        static void Register(IUnityContainer container)
        {
            new DI_Calculator.CalculationManagement.ContainerRegistratons().Register(container);
            new DI_Calculator.DisplayManagement.ContainerRegistratons().Register(container);
            new DI_Calculator.Framework.ContainerManagement.ContainerRegistrations().Register(container);            
            
            var settings = new Settings("KRB");
            container.RegisterInstance<ISettings>(settings);

        }

        static void RegisterVersionFactory(IUnityContainer container)
        {
            switch (CalculationVersion)
            {
                case DefinesVersion.V0:
                    break;

                case DefinesVersion.V1:
                    new DI_Calculator.CalculationManagement.ContainerRegistratonsV1().Register(container);
                    break;

                case DefinesVersion.V2:
                    new DI_Calculator.CalculationManagement.ContainerRegistratonsV2().Register(container); 
                    break;
                case DefinesVersion.V3:
                    new DI_Calculator.CalculationManagement.ContainerRegistratonsV3().Register(container);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Please set the featureFlag to V0, V1, V2,V3");

            }
        }



        static void Main(string[] args)
        {
            //Zorg dat je de CurrentUser capteert bij de start van de applicatie en registreer de instantie.
            //Maak dat je de usernaam kan displayen bij de displayer.
            //Fix all the tests

            CalculationVersion = "V3";

            var operandSum = "+";
            var xSum = 4;
            var ySum = 3;

            var operandMultiply = ".";
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
