using BananaParty.BehaviorTree;
using Game.Runtime.View;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public interface IBehavior : IVisualization<ITreeGraph<IReadOnlyBehaviorNode>>
    {
        void ExecuteBehavior(long time);
    }
}