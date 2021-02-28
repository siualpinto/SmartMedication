namespace WebApi.HttpStrategies.Factories
{
    public interface IFactory<T>
    {
        T Create();
    }
}
