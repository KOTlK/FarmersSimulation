using BananaParty.BehaviorTree;
using Game.Runtime.Characters;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class HasResourceNode : BehaviorNode
    {
        private readonly ICharacter _harvester;

        public HasResourceNode(ICharacter harvester)
        {
            _harvester = harvester;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _harvester.HasResourceCollected ? 
                BehaviorNodeStatus.Success : 
                BehaviorNodeStatus.Failure;
        }
    }
}