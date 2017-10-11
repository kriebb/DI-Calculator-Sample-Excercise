namespace DI_Calculator.CalculationManagement.Impl
{
    internal class MultiplyOperation : IOperation
    {
        public int Evaluate(int x, int y)
        {
            return x * y;
        }
    }
}