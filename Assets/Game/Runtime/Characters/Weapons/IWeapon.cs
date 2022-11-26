using Game.Runtime.Characters.Professions.Warrior;

namespace Game.Runtime.Characters.Weapons
{
    public interface IWeapon
    {
        void Attack();
        void Equip(IWarrior warrior);
    }
}