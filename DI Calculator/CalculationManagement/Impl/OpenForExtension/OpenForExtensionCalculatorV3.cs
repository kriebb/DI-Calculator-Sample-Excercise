using System;
using System.Linq;
using DI_Calculator.Framework.ContainerManagement;

namespace DI_Calculator.CalculationManagement.Impl.OpenForExtension
{
    internal class OpenForExtensionCalculatorV3 : ICalculator
    {
        private readonly INamedResolver _namedResolver;

        public OpenForExtensionCalculatorV3(INamedResolver namedResolver)
        {
            _namedResolver = namedResolver;
        }
        public int Calculate(string operand, int x, int y)
        {
            var operation = _namedResolver.Resolve<IOperation>(operand);
            if (operation == null)
                throw new ArgumentException($"We do not support the operation: {operand}");

            var result = operation.Evaluate(x, y);
            return result;
        }
    }
}