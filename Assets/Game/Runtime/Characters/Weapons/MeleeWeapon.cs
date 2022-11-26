using System;
using System.Linq;
using Game.Runtime.Characters.Professions.Warrior;

namespace Game.Runtime.Characters.Weapons
{
    public abstract class MeleeWeapon : IMeleeWeapon
    {
        private readonly float _damage;
        private readonly float _range;
        private readonly float _width;
        
        private IWeaponTargets _targets;
        private Party _ownerParty;

        protected MeleeWeapon(float damage, float range, float width)
        {
            _damage = damage;
            _range = range;
            _width = width;
        }

        public void Attack()
        {
            var party = GetParty(_ownerParty);
            var targets = _targets.TargetsInRange.Where(target => target.Party == party);
            
            foreach (var target in targets)
            {
                target.ApplyDamage(_damage);
            }
        }

        public void Equip(IWarrior warrior)
        {
            _ownerParty = warrior.Party;
            _targets = warrior.Targets;
            _targets.SetRange(_range);
            _targets.SetWidth(_width);
        }

        private static Party GetParty(Party current)
        {
            return current switch
            {
                Party.Enemy => Party.Friend,
                Party.Friend => Party.Enemy,
                _ => throw new ArgumentOutOfRangeException(nameof(current), current, null)
            };
        }
    }
}