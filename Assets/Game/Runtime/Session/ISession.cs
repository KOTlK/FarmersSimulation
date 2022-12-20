using BananaParty.BehaviorTree;
using Game.Runtime.Input.View;
using Game.Runtime.View;

namespace Game.Runtime.Session
{
    public interface ISession : IGameLoop, IVisualization<ITreeGraph<IReadOnlyBehaviorNode>>
    {
    }
}