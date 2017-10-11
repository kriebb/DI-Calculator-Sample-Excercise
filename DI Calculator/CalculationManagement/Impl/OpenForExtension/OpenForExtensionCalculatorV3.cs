using System;
using System.Linq;
using DI_Calculator.Framework.ContainerManagement;

namespace DI_Calculator.CalculationManagement.Impl.OpenForExtension
{
    internal class OpenForExtensionCalculatorV3 : ICalculator
    {
        private readonly INamedResolver _namedResolver;
        private readonly IKeyInputMapper _keyInputMapper;

        public OpenForExtensionCalculatorV3(INamedResolver namedResolver,IKeyInputMapper keyInputMapper)
        {
            _namedResolver = namedResolver;
            _keyInputMapper = keyInputMapper;
        }
        public int Calculate(string userOperand, int x, int y)
        {
            var operand = _keyInputMapper.Map(userOperand);
            var operation = _namedResolver.Resolve<IOperation>(operand);
            if (operation == null)
                throw new ArgumentException($"We do not support the operation: {operand}");

            var result = operation.Evaluate(x, y);
            return result;
        }
    }
}