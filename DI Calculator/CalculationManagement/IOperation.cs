namespace DI_Calculator.CalculationManagement
{
    public interface IOperation
    {
        int Evaluate(int x, int y);
        string Name { get;  }
    }
}