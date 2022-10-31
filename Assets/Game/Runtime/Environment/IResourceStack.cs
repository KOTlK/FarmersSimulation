namespace Game.Runtime.Environment
{
    public interface IResourceStack<out TResource>
    {
        bool HasResource { get; }
        TResource Pop();
    }
}