using Game.Runtime.Characters.HP;
using Game.Runtime.View.Health;

namespace Game.Runtime.Characters.Enemies.DamageResistance
{
    public class Armor : IHealth
    {
        private readonly IHealth _origin;
        private readonly float _resistance;

        private const float MaxReduction = 0.2f;

        public Armor(IHealth origin, float resistance)
        {
            _origin = origin;
            _resistance = resistance;
        }
        
        public bool IsOver => _origin.IsOver;
        public void Lose(float amount)
        {
            var cleanDamage = amount - _resistance;
            var minDamage = amount * MaxReduction;

            if (cleanDamage < minDamage)
            {
                cleanDamage = minDamage;
            }

            _origin.Lose(cleanDamage);
        }

        public void Restore(float amount) => _origin.Restore(amount);
        public void Visualize(IHealthView view) => _origin.Visualize(view);
    }
}