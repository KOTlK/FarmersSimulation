using BananaParty.BehaviorTree;
using Game.Runtime.Characters.Professions.Harvester;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class HasResourceNode : BehaviorNode
    {
        private readonly IHarvester _harvester;

        public HasResourceNode(IHarvester harvester)
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