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
            //Zorg ervoor dat je applicatie werkt met 'Add', naast ook Multiply te kennen, op basis van een parameter. Multiply = * en Add = +
            //Zorg ervoor dat je 4+3 uitkomt
            //Indien een niet gekende operatie gebruikt wordt, gaat de applicatie een exception smijten.
            var operation = "+";

            var x = 4;
            var y = 3;
            int result = 0;
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

            Console.WriteLine(result);
            Console.ReadKey();
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
