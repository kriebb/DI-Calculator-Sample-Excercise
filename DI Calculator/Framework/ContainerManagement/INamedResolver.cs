namespace DI_Calculator.Framework.ContainerManagement
{
    public interface INamedResolver
    {
        T Resolve<T>(string name);
    }
}