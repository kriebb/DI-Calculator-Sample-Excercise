using System;
using DI_Calculator.Shared;

namespace DI_Calculator.CalculationManagement.Impl.Simple
{
    internal class SimpleCalculator:ICalculator
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
                case Defines.Multiplication:
                    result = Multiply(x, y);
                    break;
                case Defines.Sum:
                    result = Add(x, y);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"We ondersteunen niet de operatie: {operation} enkel maar de operatie * of +");
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
}