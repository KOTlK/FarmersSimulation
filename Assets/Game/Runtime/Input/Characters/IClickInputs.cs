namespace Game.Runtime.Input.Characters
{
    public interface IClickInputs<out T>
    {
        bool HasUnreadInput { get; }
        T GetInput();
        void Clear();
    }
}