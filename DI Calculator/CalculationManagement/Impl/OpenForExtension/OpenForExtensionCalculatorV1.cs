namespace DI_Calculator.CalculationManagement.Impl.OpenForExtension
{
    internal class OpenForExtensionCalculatorV1 : ICalculator
    {
        private readonly IOperationFactory _operationFactory;

        public OpenForExtensionCalculatorV1(IOperationFactory operationFactory)
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