using DI_Calculator.Shared;

namespace DI_Calculator.CalculationManagement.Impl.OpenForExtension.Operations
{
    internal class SommationOperation : IOperation
    {
        public int Evaluate(int x, int y)
        {
            return x + y;
        }

        public string Name => Defines.Sum;
    }
}