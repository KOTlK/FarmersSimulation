namespace Game.Runtime.Dynamic
{
    public interface IFactory<out T>
    {
        T Create();
    }
}