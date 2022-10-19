using UnityEngine;

namespace Game.Runtime.Input.View
{
    public class UIRoot : MonoBehaviour, IUserInterfaceRoot
    {
        [SerializeField] private CharacterInfoPanel _characterInfo = null;
        public ICharacterInfoPanel CharacterInfoPanel => _characterInfo;
    }
}