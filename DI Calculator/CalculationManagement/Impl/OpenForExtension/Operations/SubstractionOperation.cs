namespace DI_Calculator.CalculationManagement.Impl
{
    internal class SubstractionOperation : IOperation
    {
        public int Evaluate(int x, int y)
        {
            return x - y;
        }
    }
}