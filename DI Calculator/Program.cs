using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DI_Calculator
{
    internal class ResultDisplayer
    {
        public void Display(string origin, int result)
        {
            Console.WriteLine(string.Format($"{origin}: result:{result}"));
            Console.ReadKey();
        }
    }
    internal class Startup
    {

        public void Start(string operation, int x, int y)
        {
            var result = new SimpleCalculator().Calculate(operation, x, y);

            new ResultDisplayer().Display(operation, result);
        }
    }

    internal class SimpleCalculator
    {
        public int Calculate(string operation, int x, int y)
        {
            return OperationFactory(operation, x, y);
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

        private static int Multiply(int x, int y)
        {
            return x * y;
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            //Refactor: next step: Weg van statics!
            //Code is for production.
            //Ik wil twee instanties om te rekenen. Eén voor 4+3 en één voor 4*3
            //De beide instanties moeten kunnen displayen naar de console op dezelfde manier.
            //Zorg dat je weet welk resultaat komt van welke calculator


            var operation1 = "+";

            var x1 = 4;
            var y1 = 3;

            var operation2 = "*";
            var x2 = 4;
            var y2 = 3;

            new Startup().Start(operation1, x1, y1);
            new Startup().Start(operation2, x2, y2);

        }





    }
}
