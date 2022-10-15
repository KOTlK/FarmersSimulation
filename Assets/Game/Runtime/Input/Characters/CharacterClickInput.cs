using System;
using Game.Runtime.Characters;
using UnityEngine;

namespace Game.Runtime.Input.Characters
{
    public class CharacterClickInput : MonoBehaviour, IClickInput<ICharacter>
    {
        public event Action<ICharacter> Clicked = delegate {  };
        
        [SerializeField] private Character _character;

        private void OnMouseDown()
        {
            Clicked.Invoke(_character);
        }
    }
}