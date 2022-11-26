using Game.Runtime.View.Characters;

namespace Game.Runtime.Input.View
{
    public interface ICharacterInfoElement : IElement
    {
        IFriendlyCharacterView FriendlyCharacterView { get; }
        IButton CloseButton { get; }
    }
}