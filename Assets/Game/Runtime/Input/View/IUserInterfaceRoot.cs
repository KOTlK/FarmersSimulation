using Game.Runtime.View.Storage;

namespace Game.Runtime.Input.View
{
    public interface IUserInterfaceRoot
    {
        ICharacterInfoElement CharacterInfoElement { get; }
        ResourceStorageView StorageElement { get; }
    }
}