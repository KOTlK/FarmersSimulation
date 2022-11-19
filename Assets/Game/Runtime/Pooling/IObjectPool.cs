namespace Game.Game.Runtime.Pooling
{
    public interface IObjectPool<T>
    {
        T Pop();
        void Return(T obj);
    }
}