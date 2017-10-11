using System;

namespace DI_Calculator.CalculationManagement.Impl.OpenForExtension.Operations
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
                case "-":
                    return new SubstractionOperation();
                case "/":
                    return new DivisionOperation();

                default:
                    throw new ArgumentOutOfRangeException($"{nameof(operation)} - {operation}");

            }
        }
    }
}