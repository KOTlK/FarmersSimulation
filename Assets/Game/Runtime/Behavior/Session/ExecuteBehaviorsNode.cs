using System.Collections.Generic;
using BananaParty.BehaviorTree;
using Game.Runtime.Behavior.Characters.Professions;

namespace Game.Runtime.Behavior.Session
{
    public class ExecuteBehaviorsNode : BehaviorNode
    {
        private readonly IEnumerable<IBehavior> _behaviors;

        public ExecuteBehaviorsNode(IEnumerable<IBehavior> behaviors)
        {
            _behaviors = behaviors;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            foreach (var behavior in _behaviors)
            {
                behavior.Execute(time);
            }

            return BehaviorNodeStatus.Success;
        }
    }
}