using Game.Runtime.Input.View.PauseMenu;
using Game.Runtime.View.DateTime;
using Game.Runtime.View.Screens;
using Game.Runtime.View.Storage;
using UnityEngine;

namespace Game.Runtime.Input.View
{
    public class UIRoot : MonoBehaviour, IUserInterfaceRoot
    {
        [SerializeField] private CharacterInfoElement _characterInfo = null;
        [SerializeField] private ResourceStorageView _storageView = null;
        [SerializeField] private DateTimeView _dateTimeView = null;
        [SerializeField] private Viewport _viewport;
        [SerializeField] private PauseMenu.PauseMenu _pauseMenu;
        public ICharacterInfoElement CharacterInfoElement => _characterInfo;
        public ResourceStorageView StorageElement => _storageView;
        public ITimeView Time => _dateTimeView;
        public IDateView Date => _dateTimeView;
        public IViewport Viewport => _viewport;
        public IPauseMenu PauseMenu => _pauseMenu;
    }
}