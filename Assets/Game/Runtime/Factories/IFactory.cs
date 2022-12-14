namespace Game.Runtime.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}