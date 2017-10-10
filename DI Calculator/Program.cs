using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DI_Calculator
{
    class Program
    {

        static void Main(string[] args)
        {
            //Refactor: Zorg dat enkel de input (values, operator) en startup in de main staan.
            //Refactor: je hebt een 'DoWork' die de parameters bevat
            //Refactor: Zorg ervoor dat de switch gecontained is. Een Switch = Smell naar factory.

            var operation = "+";

            var x = 4;
            var y = 3;


            DoWork(operation, x, y);
        }

        private static void DoWork(string operation, int x, int y)
        {
            var result = OperationFactory(operation, x, y);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static int OperationFactory(string operation, int x, int y)
        {
            int result;
            switch (operation)
            {
                case "*":
                    result = Multiply(x, y);
                    break;
                case "+":
                    result = Add(x, y);
                    break;
                default:
                    throw new ArgumentException($"We ondersteunen niet de operatie: {operation} enkel maar de operatie * of +");
            }
            return result;
        }

        static int Multiply(int x, int y)
        {
            return x * y;
        }

        static int Add(int x, int y)
        {
            return x + y;
        }
    }
}
