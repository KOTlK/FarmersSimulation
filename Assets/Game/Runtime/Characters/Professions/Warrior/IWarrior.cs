using Game.Runtime.Characters.Weapons;
using Game.Runtime.View;
using Game.Runtime.View.Characters.Warrior;

namespace Game.Runtime.Characters.Professions.Warrior
{
    public interface IWarrior : IFriendlyCharacter, IDamageable, IVisualization<IWarriorView>
    {
        IWeaponTargets Targets { get; }
        void Attack();
        void EquipWeapon(IWeapon weapon);
    }
}