namespace DI_Calculator.DisplayManagement
{
    public interface IOutputBuilderResult
    {
        string Generate(params object[] parameters);
    }
}