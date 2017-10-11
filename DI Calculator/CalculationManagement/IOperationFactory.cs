namespace DI_Calculator.CalculationManagement.Impl
{
    public interface IOperationFactory
    {
        IOperation Create(string operation);
    }
}