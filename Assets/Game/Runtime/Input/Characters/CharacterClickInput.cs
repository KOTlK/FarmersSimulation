using System;
using Game.Runtime.Characters;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Runtime.Input.Characters
{
    public class CharacterClickInput : MonoBehaviour, IClickInput<ICharacter>
    {
        public event Action<ICharacter> Clicked = delegate {  };
        
        [SerializeField] private Character _character;

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            
            Clicked.Invoke(_character);
        }
    }
}