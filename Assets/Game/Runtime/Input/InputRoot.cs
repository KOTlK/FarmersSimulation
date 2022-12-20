using Game.Runtime.Input.Click;
using UnityEngine;

namespace Game.Runtime.Input
{
    public class InputRoot : MonoBehaviour, IInputRoot
    {
        [SerializeField] private Mouse _mouse;
        public IMouse Mouse => _mouse;
    }
}