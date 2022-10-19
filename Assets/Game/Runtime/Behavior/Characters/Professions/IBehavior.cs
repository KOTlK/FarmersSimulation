using BananaParty.BehaviorTree;
using Game.Runtime.Session;
using Game.Runtime.View;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public interface IBehavior : IVisualization<ITreeGraph<IReadOnlyBehaviorNode>>, IGameLoop
    {
    }
}