using UnityEngine;

namespace Game.Runtime.View.World.Smoke
{
    public class SmokeCloud : MonoBehaviour
    {
        [SerializeField] private SmokePart _partPrefab;
        [SerializeField, Min(1)] private int _partsAmount;
        [SerializeField, Min(0)] private float _minRadius = 0.5f;
        [SerializeField, Min(0)] private float _maxRadius = 5f;

        private SmokePart[] _parts;

        private void Awake()
        {
            _parts = new SmokePart[_partsAmount];
            
            for (var i = 0; i < _partsAmount; i++)
            {
                _parts[i] = Instantiate(_partPrefab, transform);
            }
            Regenerate();
        }

        [ContextMenu(nameof(Regenerate))]
        public void Regenerate()
        {
            var position = Vector2.zero;
            var radius = UnityEngine.Random.Range(_minRadius, _maxRadius);
            
            foreach (var part in _parts)
            {
                part.transform.localPosition = position;
                part.Radius = radius;
                
                var direction = UnityEngine.Random.insideUnitCircle.normalized;
                position += direction * radius;
                radius = UnityEngine.Random.Range(_minRadius, _maxRadius);
            }
        }

        
    }
}