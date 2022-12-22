using UnityEngine;

namespace Game.Runtime.Input.Player
{
    public class KeyboardInput : IPlayerInput
    {
        public bool BackButtonPressed => UnityEngine.Input.GetKeyDown(KeyCode.Escape);
    }
}