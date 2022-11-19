using Game.Runtime.View;
using Game.Runtime.View.Health;

namespace Game.Runtime.Characters.HP
{
    public interface IHealth : IVisualization<IHealthView>
    {
        bool IsOver { get; }
        void Lose(float amount);
        void Restore(float amount);
    }
}