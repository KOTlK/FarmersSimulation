using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Runtime.View.World.Bezier
{
    public class CurveTest : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Transform _target;
        [SerializeField] private BezierCurve _curve;

        private void Awake()
        {
            _slider.onValueChanged.AddListener(SetTargetPosition);
        }

        private void SetTargetPosition(float t)
        {
            _target.position = _curve.Lerp(t);
        }
    }
}