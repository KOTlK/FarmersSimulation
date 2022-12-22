using Game.Runtime.Input.Click;
using Game.Runtime.Input.Player;
using UnityEngine;

namespace Game.Runtime.Input
{
    public class InputRoot : MonoBehaviour, IInputRoot
    {
        [SerializeField] private Mouse _mouse;
        
        private readonly IPlayerInput _keyboardInput = new KeyboardInput();
        
        public IMouse Mouse => _mouse;
        public IPlayerInput PlayerInput => _keyboardInput;
    }
}