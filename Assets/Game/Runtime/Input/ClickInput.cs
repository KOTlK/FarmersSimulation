using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Runtime.Input
{
    public abstract class ClickInput<T, TBehavior> : MonoBehaviour, IClickInput<T>
    where TBehavior : MonoBehaviour, T
    {
        [SerializeField] private TBehavior _target = null;
        
        public event Action<T> Clicked = delegate { };
        
        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Clicked.Invoke(_target);
        }
    }
}