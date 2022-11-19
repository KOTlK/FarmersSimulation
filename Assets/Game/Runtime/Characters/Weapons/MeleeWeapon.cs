namespace Game.Runtime.Characters.Weapons
{
    public abstract class MeleeWeapon : IMeleeWeapon
    {
        private readonly IWeaponTargets _targets;
        private readonly float _damage;

        protected MeleeWeapon(IWeaponTargets targets, float damage, float range, float width)
        {
            _targets = targets;
            _damage = damage;
            _targets.SetRange(range);
            _targets.SetWidth(width);
        }

        public void Attack()
        {
            foreach (var target in _targets.TargetsInRange)
            {
                target.ApplyDamage(_damage);
            }
        }

    }
}