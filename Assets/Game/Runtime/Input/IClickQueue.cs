namespace Game.Runtime.Input
{
    public interface IClickQueue<out T>
    {
        bool HasUnreadInput { get; }
        T GetInput();
        void Clear();
    }
}