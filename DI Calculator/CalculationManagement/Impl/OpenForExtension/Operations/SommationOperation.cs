namespace DI_Calculator.CalculationManagement.Impl
{
    internal class SommationOperation : IOperation
    {
        public int Evaluate(int x, int y)
        {
            return x + y;
        }
    }
}