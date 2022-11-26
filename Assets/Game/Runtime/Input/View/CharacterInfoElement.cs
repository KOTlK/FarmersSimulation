using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Input.View
{
    public class CharacterInfoElement : MonoBehaviour, ICharacterInfoElement
    {
        [SerializeField] private Button _closeButton = null;
        [SerializeField] private FriendlyCharacterView _friendlyCharacterView = null;

        public bool IsActive
        {
            get => gameObject.activeSelf;
            set
            {
                if (gameObject.activeSelf != value)
                    gameObject.SetActive(value);
            }
        }

        public IButton CloseButton => _closeButton;

        public IFriendlyCharacterView FriendlyCharacterView => _friendlyCharacterView;
    }
}