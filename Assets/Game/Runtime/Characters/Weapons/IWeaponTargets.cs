using System.Collections.Generic;
using Game.Runtime.Characters.Professions.Warrior;

namespace Game.Runtime.Characters.Weapons
{
    public interface IWeaponTargets
    {
        IEnumerable<IDamageable> TargetsInRange { get; }
        void SetRange(float range);
        void SetWidth(float width);
    }
}