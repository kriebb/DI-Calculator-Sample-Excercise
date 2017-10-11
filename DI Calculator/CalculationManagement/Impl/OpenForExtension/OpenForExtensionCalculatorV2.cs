using System;
using System.Linq;

namespace DI_Calculator.CalculationManagement.Impl.OpenForExtension
{
    internal class OpenForExtensionCalculatorV2 : ICalculator
    {
        private readonly IOperation[] _operations;

        public OpenForExtensionCalculatorV2(IOperation[] operations)
        {
            _operations = operations;
        }
        public int Calculate(string operand, int x, int y)
        {
            var operation = _operations.SingleOrDefault(ofOperations => ofOperations.Name == operand);
            if (operation == null)
                throw new ArgumentException($"We do not support the operation: {operand}");

            var result = operation.Evaluate(x, y);
            return result;
        }
    }
}