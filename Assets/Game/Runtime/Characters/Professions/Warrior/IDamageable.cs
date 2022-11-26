namespace Game.Runtime.Characters.Professions.Warrior
{
    public interface IDamageable
    {
        Party Party { get; }
        bool IsDead { get; }
        void ApplyDamage(float amount);
    }
}