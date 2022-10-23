namespace Game.Runtime.Input.View.Storage
{
    public interface IStorageElement : IElement
    {
        IButton CloseButton { get; }
    }
}