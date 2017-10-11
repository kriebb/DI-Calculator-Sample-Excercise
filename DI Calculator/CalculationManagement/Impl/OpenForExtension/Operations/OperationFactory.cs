using System;

namespace DI_Calculator.CalculationManagement.Impl
{
    internal class OperationFactory : IOperationFactory
    {
        public IOperation Create(string operation)
        {
            switch (operation)
            {
                case "*":
                    return new MultiplyOperation();

                case "+":
                    return new SommationOperation();
                default:
                    throw new ArgumentOutOfRangeException($"{nameof(operation)} - {operation}");

            }
        }
    }
}