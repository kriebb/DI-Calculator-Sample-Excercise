using DI_Calculator.CalculationManagement;
using DI_Calculator.DisplayManagement;

namespace DI_Calculator.Bootstrap
{
    internal class Startup
    {
        private readonly ICalculator _calculator;
        private readonly IDisplayer _displayer;

        public Startup(ICalculator calculator, IDisplayer displayer)
        {
            _calculator = calculator;
            _displayer = displayer;
        }
        public void Start(string operation, int x, int y)
        {
            var result = _calculator.Calculate(operation, x, y);

            _displayer.Display(operation, result);
        }
    }
}