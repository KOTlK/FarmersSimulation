using Game.Runtime.View.World.Bezier;
using UnityEngine;

namespace Game.Runtime.View.World.Smoke
{
    public class SmokeMovement : MonoBehaviour
    {
        [SerializeField] private BezierCurve _curve;
        [SerializeField] private SmokeCloud _cloud;
        [SerializeField] private float _minMovementTime = 3f;
        [SerializeField] private float _maxMovementTime = 10f;

        private float _maxTime;
        private float _time = 0f;

        private void Awake()
        {
            _maxTime = UnityEngine.Random.Range(_minMovementTime, _maxMovementTime);
        }

        private void Update()
        {
            if (_time >= _maxTime)
            {
                _time = 0f;
                _maxTime = UnityEngine.Random.Range(_minMovementTime, _maxMovementTime);
                _cloud.Regenerate();
                _curve.RandomizeHorizontal();
            }

            _time += Time.deltaTime;
            var delta = _time / _maxTime;
            _cloud.transform.position = _curve.Evaluate(delta);
        }
    }
}