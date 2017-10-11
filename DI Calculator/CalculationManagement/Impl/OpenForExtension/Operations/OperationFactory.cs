using System;
using DI_Calculator.Shared;

namespace DI_Calculator.CalculationManagement.Impl.OpenForExtension.Operations
{
    internal class OperationFactory : IOperationFactory
    {
        public IOperation Create(string operation)
        {
            switch (operation)
            {
                case Defines.Multiplication:
                    return new MultiplyOperation();
                case Defines.Sum:
                    return new SommationOperation();
                case Defines.Substraction:
                    return new SubstractionOperation();
                case Defines.Division:
                    return new DivisionOperation();

                default:
                    throw new ArgumentOutOfRangeException($"{nameof(operation)} - {operation}");

            }
        }
    }
}