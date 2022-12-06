using UnityEngine;

namespace Game.Runtime.View.World.Bezier
{
    public class BezierCurve : MonoBehaviour
    {
        [SerializeField] private Transform _point0, _point1, _point2, _point3;
        [SerializeField] private int _gizmosSegmentsAmount = 30;

        [Space] [Header("Random")] 
        [SerializeField] private float _minDeviation;
        [SerializeField] private float _maxDeviation;

        //B(t) = (1 - t)^3*P0 + 3t*(1-t)^2*P1 + 3t^2*(1 - t)*P2 + t^3*P3
        public Vector3 Evaluate(float t)
        {
            var tMinus = 1 - t;

            return Mathf.Pow(tMinus, 3) * _point0.position +
                   3 * t * Mathf.Pow(tMinus, 2) * _point1.position +
                   3 * Mathf.Pow(t, 2) * tMinus * _point2.position +
                   Mathf.Pow(t, 3) * _point3.position;
        }

        /// <summary>
        /// Randomize point0 and point1 positions on horizontal axis. In this case point1 will be left and point2 - right
        /// </summary>
        public void RandomizeHorizontal()
        {
            Vector2 center = (_point3.localPosition - _point0.localPosition) / 2;

            var leftDeviation = UnityEngine.Random.Range(_minDeviation, _maxDeviation);
            var rightDeviation = UnityEngine.Random.Range(_minDeviation, _maxDeviation);

            var leftDirection = UnityEngine.Random.insideUnitCircle.normalized;
            leftDirection.x = Mathf.Abs(leftDirection.x) * -1;
            
            var rightDirection = UnityEngine.Random.insideUnitCircle.normalized;
            rightDirection.x = Mathf.Abs(rightDirection.x);

            var leftPosition = center + leftDirection * leftDeviation;
            var rightPosition = center + rightDirection * rightDeviation;

            _point1.localPosition = leftPosition;
            _point2.localPosition = rightPosition;
        }

        private void OnDrawGizmos()
        {
            var position = _point0.position;
            
            for (var i = 0; i <= _gizmosSegmentsAmount; i++)
            {
                var t = (float)i / _gizmosSegmentsAmount;
                var nextPosition = Evaluate(t);
                Gizmos.DrawLine(position, nextPosition);
                position = nextPosition;
            }
        }
    }
}