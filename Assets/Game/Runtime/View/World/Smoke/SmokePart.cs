using UnityEngine;

namespace Game.Runtime.View.World.Smoke
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SmokePart : MonoBehaviour
    {
        private float _radius = 0.5f;

        public float Radius
        {
            get => _radius;
            set
            {
                _radius = value;
                var scale = CalculateScale(_radius);
                transform.localScale = new Vector3(scale, scale, 1);
            }
        }

        private static float CalculateScale(float radius) => radius * 2f;
    }
}