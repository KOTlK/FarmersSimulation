using System.Collections.Generic;
using BananaParty.BehaviorTree;
using Game.Runtime.Session;

namespace Game.Runtime.Behavior.Session
{
    public class ExecuteGameLoop : BehaviorNode
    {
        private readonly IEnumerable<IGameLoop> _loops;

        public ExecuteGameLoop(IEnumerable<IGameLoop> loops)
        {
            _loops = loops;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            foreach (var loop in _loops)
            {
                loop.Execute(time);
            }

            return BehaviorNodeStatus.Success;
        }
    }
}