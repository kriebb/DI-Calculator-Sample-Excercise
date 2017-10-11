using System;

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
}