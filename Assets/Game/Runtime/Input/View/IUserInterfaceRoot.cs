using Game.Runtime.Input.View.PauseMenu;
using Game.Runtime.View.DateTime;
using Game.Runtime.View.Screens;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Input.View
{
    public interface IUserInterfaceRoot
    {
        ICharacterInfoElement CharacterInfoElement { get; }
        ResourceStorageView StorageElement { get; }
        ITimeView Time { get; }
        IDateView Date { get; }
        IViewport Viewport { get; }
        IPauseMenu PauseMenu { get; }
    }
}