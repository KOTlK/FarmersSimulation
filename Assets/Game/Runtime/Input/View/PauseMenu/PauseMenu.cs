using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Runtime.Input.View.PauseMenu
{
    public class PauseMenu : MonoBehaviour, IPauseMenu
    {
        [SerializeField] private Button _continue;
        [SerializeField] private Button _exit;
        [SerializeField] private float _maxRadius = 8f;
        [SerializeField] private float _minRadius = 0f;
        [SerializeField] private float _minImageAlpha = 0f;
        [SerializeField] private float _maxImageAlpha = 0.1f;
        [SerializeField] private float _fadeTime = 1.5f;

        private Image _image;
        private Material _material;
        private Coroutine _coroutine;
        
        private static readonly int _radius = Shader.PropertyToID("_Radius");
        
        private void Awake()
        {
            _image = GetComponent<Image>();
            _material = _image.material;
        }

        public IButton Continue => _continue;
        public IButton Exit => _exit;

        public bool IsActive
        {
            get => gameObject.activeSelf;
            set
            {
                if (gameObject.activeSelf != value)
                {
                    if (value == true)
                        gameObject.SetActive(true);
                    if(_coroutine != null) 
                        StopCoroutine(_coroutine);
                    
                    StartCoroutine(Appearing(_fadeTime, value));
                }
            }
        }

        private IEnumerator Appearing(float time, bool revert)
        {
            var timeElapsed = 0f;

            while (timeElapsed < time)
            {
                var delta = timeElapsed / time;
                
                var radius = revert == false
                    ? Mathf.Lerp(_maxRadius, _minRadius, delta)
                    : Mathf.Lerp(_minRadius, _maxRadius, delta);

                var alpha = revert == false
                    ? Mathf.Lerp(_maxImageAlpha, _minImageAlpha, delta)
                    : Mathf.Lerp(_minImageAlpha, _maxImageAlpha, delta);

                var color = _image.color;
                
                color.a = alpha;
                _material.SetFloat(_radius, radius);
                _image.color = color;
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            
            gameObject.SetActive(revert);
        }
    }
}