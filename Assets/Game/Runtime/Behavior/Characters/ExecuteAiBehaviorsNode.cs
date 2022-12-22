using System.Collections.Generic;
using BananaParty.BehaviorTree;

namespace Game.Runtime.Behavior.Characters
{
    public class ExecuteAiBehaviorsNode : BehaviorNode
    {
        private readonly IEnumerable<IBehaviorNode> _nodes;

        public ExecuteAiBehaviorsNode(IEnumerable<IBehaviorNode> nodes)
        {
            _nodes = nodes;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            foreach (var node in _nodes)
            {
                node.Execute(time);
            }

            return BehaviorNodeStatus.Success;
        }
    }
}