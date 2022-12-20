using System.Collections.Generic;
using BananaParty.BehaviorTree;

namespace Game.Runtime.Behavior.Characters
{
    public class ExecuteBehaviorsNode : BehaviorNode
    {
        private readonly IEnumerable<IBehaviorNode> _nodes;

        public ExecuteBehaviorsNode(IEnumerable<IBehaviorNode> nodes)
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