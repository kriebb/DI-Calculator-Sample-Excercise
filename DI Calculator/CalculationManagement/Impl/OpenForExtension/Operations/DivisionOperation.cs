namespace DI_Calculator.CalculationManagement.Impl
{
    internal class DivisionOperation : IOperation
    {
        public int Evaluate(int x, int y)
        {
            return x / y;
        }
    }
}