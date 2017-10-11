using System;

namespace DI_Calculator.CalculationManagement.Impl
{
    internal class OpenForExtensionCalculator : ICalculator
    {
        private readonly IOperationFactory _operationFactory;

        public OpenForExtensionCalculator(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }
        public int Calculate(string operand, int x, int y)
        {
            var operation = _operationFactory.Create(operand);
            var result = operation.Evaluate(x, y);
            return result;
        }
    }
}