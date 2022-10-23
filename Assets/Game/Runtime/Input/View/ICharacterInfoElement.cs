using Game.Runtime.View.Characters;

namespace Game.Runtime.Input.View
{
    public interface ICharacterInfoElement : IElement
    {
        ICharacterView CharacterView { get; }
        IButton CloseButton { get; }
    }
}