using Game.Runtime.View.Health;
using UnityEngine;

namespace Game.Runtime.Characters.HP
{
    public class Health : IHealth
    {
        private float _current;
        private readonly float _max;
        private readonly float _min;

        public Health(float min, float max)
        {
            _max = max;
            _min = min;
        }

        public bool IsOver => _current <= _min;
        
        public void Lose(float amount)
        {
            _current = Mathf.Clamp(_current - amount, _min, _max);
        }

        public void Restore(float amount)
        {
            _current = Mathf.Clamp(_current + amount, _min, _max);
        }
        
        public void Visualize(IHealthView view)
        {
            view.DisplayHealth(_current);
        }
    }
}