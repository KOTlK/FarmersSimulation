using System;
using System.Linq;
using UnityEngine;

namespace Game.Runtime.View.World.Bezier
{
    public class BezierCurve : MonoBehaviour
    {
        [SerializeField] private Transform _point0, _point1, _point2, _point3;
        [SerializeField] private int _gizmosSegmentsAmount = 30;

        //B(t) = (1 - t)^3*P0 + 3t*(1-t)^2*P1 + 3t^2*(1 - t)*P2 + t^3*P3
        public Vector3 Lerp(float t)
        {
            var tMinus = 1 - t;

            return Mathf.Pow(tMinus, 3) * _point0.position +
                   3 * t * Mathf.Pow(tMinus, 2) * _point1.position +
                   3 * Mathf.Pow(t, 2) * tMinus * _point2.position +
                   Mathf.Pow(t, 3) * _point3.position;
        }

        private void OnDrawGizmos()
        {
            var position = _point0.position;
            
            for (var i = 0; i <= _gizmosSegmentsAmount; i++)
            {
                var t = (float)i / _gizmosSegmentsAmount;
                var nextPosition = Lerp(t);
                Gizmos.DrawLine(position, nextPosition);
                position = nextPosition;
            }
        }
    }
}