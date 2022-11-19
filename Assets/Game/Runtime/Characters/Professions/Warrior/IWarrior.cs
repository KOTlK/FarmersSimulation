using Game.Runtime.View;
using Game.Runtime.View.Health;

namespace Game.Runtime.Characters.Professions.Warrior
{
    public interface IWarrior : ICharacter, IDamageable, IVisualization<IHealthView>
    {
        
    }
}