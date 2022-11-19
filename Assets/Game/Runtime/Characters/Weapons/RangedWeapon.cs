
using Game.Game.Runtime.Pooling;

namespace Game.Runtime.Characters.Weapons
{
    public class RangedWeapon : IWeapon
    {
        private readonly ICrosshair _crosshair;
        private readonly IObjectPool<IProjectile> _pool;

        public RangedWeapon(ICrosshair crosshair, IObjectPool<IProjectile> pool)
        {
            _crosshair = crosshair;
            _pool = pool;
        }

        public void Attack()
        {
            var projectile = _pool.Pop();
            projectile.Shoot(_crosshair.Direction);
        }
    }
}