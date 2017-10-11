namespace DI_Calculator.DisplayManagement.Impl
{
    public interface IOutputBuilderResult
    {
        string Generate(params object[] parameters);
    }
}