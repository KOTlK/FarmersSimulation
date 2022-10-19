using UnityEngine;

namespace Game.Runtime.Input.View
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class Button : MonoBehaviour, IButton
    {
        private UnityEngine.UI.Button _origin;

        private void Awake()
        {
            _origin = GetComponent<UnityEngine.UI.Button>();
            _origin.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            _origin.onClick.RemoveListener(OnClick);
        }

        [field: SerializeField] public bool Clicked { get; private set; }
        
        public void Reset()
        {
            Clicked = false;
        }

        private void OnClick()
        {
            if (Clicked == false)
                Clicked = true;
        }
    }
}