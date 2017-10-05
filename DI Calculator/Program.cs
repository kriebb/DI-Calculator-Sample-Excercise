using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Calculator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Werk nu met een methode, zodanig dat je geen logging moet schrijven dat je x met y *
            var x = 4;
            var y = 3;
            var multiplied = Multiply(x, y);
            Console.WriteLine(multiplied);
            Console.ReadKey();
        }

        static int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
