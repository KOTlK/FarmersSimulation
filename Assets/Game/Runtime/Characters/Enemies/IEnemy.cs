using Game.Runtime.Characters.Professions.Warrior;

namespace Game.Runtime.Characters.Enemies
{
    public interface IEnemy : ICharacter, IDamageable
    {
        void Attack();
    }
}