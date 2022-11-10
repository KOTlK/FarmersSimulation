using BananaParty.BehaviorTree;
using Game.Runtime.Characters.Professions.Farmer;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class HasWheatNode : BehaviorNode
    {
        private readonly IHarvester _harvester;

        public HasWheatNode(IHarvester harvester)
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