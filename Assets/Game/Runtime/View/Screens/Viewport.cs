using System;
using Game.Runtime.Input.View.PauseMenu;
using UnityEngine;

namespace Game.Runtime.View.Screens
{
    public class Viewport : MonoBehaviour, IViewport
    {
        [SerializeField] private PauseMenu _pauseMenu;
        

        private Screen _current = Screen.Game;
        
        public void SwitchScreen(Screen screen)
        {
            if (screen == _current)
                return;

            
            switch (screen)
            {
                case Screen.Game:
                    _pauseMenu.IsActive = false;
                    break;
                case Screen.PauseMenu:
                    _pauseMenu.IsActive = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(screen), screen, null);
            }

            _current = screen;
        }

    }
}