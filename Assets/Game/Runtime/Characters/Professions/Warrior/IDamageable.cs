namespace Game.Runtime.Characters.Professions.Warrior
{
    public interface IDamageable
    {
        bool IsDead { get; }
        void ApplyDamage(float amount);
    }
}