namespace Game.Runtime.Input
{
    public interface ISelectedElement<in T>
    {
        bool Exist { get; }
        void Add(T element);
        void Reset();
    }
}