namespace DI_Calculator.DisplayManagement.Impl
{
    internal class ResultFactory : IOutputBuilderResult
    {

        public string Generate(params object[] parameters)
        {
            return string.Format($"{parameters[0]} | {parameters[1]}: {parameters[2]}");

        }
    }
}