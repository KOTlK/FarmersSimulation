using Game.Runtime.Characters.HP;
using Game.Runtime.Characters.Weapons;
using Game.Runtime.View.Characters.Warrior;
using UnityEngine;

namespace Game.Runtime.Characters.Professions.Warrior
{
    public class Warrior : FriendlyCharacter, IWarrior
    {
        [SerializeField] private Party _party;
        [SerializeField] private WeaponTargets _targets;
        [SerializeField] private float _maxHp = 100f;
        [SerializeField] private float _minHp = 0f;

        private IHealth _health;
        private IWeapon _selectedWeapon;

        private void Start()
        {
            _health = new Health(_minHp, _maxHp);
        }

        public bool IsDead => _health.IsOver;
        public override Profession Profession => Profession.Warrior;
        public Party Party => _party;
        
        public void ApplyDamage(float amount) => _health.Lose(amount);
        public IWeaponTargets Targets => _targets;
        public void Attack() => _selectedWeapon.Attack();

        public void EquipWeapon(IWeapon weapon)
        {
            _selectedWeapon = weapon;
            weapon.Equip(this);
        }

        public void Visualize(IWarriorView view)
        {
            view.DisplayWeapon(_selectedWeapon);
            _health.Visualize(view);
        }
    }
}