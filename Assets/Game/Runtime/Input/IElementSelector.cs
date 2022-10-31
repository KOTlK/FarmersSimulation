namespace Game.Runtime.Input
{
    public interface IElementSelector<in T>
    {
        bool Exist { get; }
        void Select(T element);
        void Reset();
    }
}