using Game.Runtime.Input.View.Storage;
using Game.Runtime.View.Storage;
using UnityEngine;

namespace Game.Runtime.Input.View
{
    public class UIRoot : MonoBehaviour, IUserInterfaceRoot
    {
        [SerializeField] private CharacterInfoElement _characterInfo = null;
        [SerializeField] private ResourceStorageView _storageView = null;
        public ICharacterInfoElement CharacterInfoElement => _characterInfo;
        public ResourceStorageView StorageElement => _storageView;
    }
}