namespace Game.Runtime.Input.View
{
    public interface IButton
    {
        bool Clicked { get; }
        void Reset();
    }
}