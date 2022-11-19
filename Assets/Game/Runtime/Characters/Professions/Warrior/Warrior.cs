using Game.Runtime.Characters.HP;
using Game.Runtime.View.Health;
using UnityEngine;

namespace Game.Runtime.Characters.Professions.Warrior
{
    public class Warrior : Character, IWarrior
    {
        [SerializeField] private float _maxHp = 100f;
        [SerializeField] private float _minHp = 0f;

        private IHealth _health;

        private void Start()
        {
            _health = new Health(_minHp, _maxHp);
        }

        public bool IsDead => _health.IsOver;
        public override Profession Profession => Profession.Warrior;
        
        public void ApplyDamage(float amount) => _health.Lose(amount);
        public void Visualize(IHealthView view) => _health.Visualize(view);

        
    }
}