using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Input.View
{
    public class CharacterInfoPanel : MonoBehaviour, ICharacterInfoPanel
    {
        [SerializeField] private Button _closeButton = null;
        [SerializeField] private CharacterView _characterView = null;

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

        public ICharacterView CharacterView => _characterView;
    }
}