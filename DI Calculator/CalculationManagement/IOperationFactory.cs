namespace DI_Calculator.CalculationManagement
{
    public interface IOperationFactory
    {
        IOperation Create(string operation);
    }
}