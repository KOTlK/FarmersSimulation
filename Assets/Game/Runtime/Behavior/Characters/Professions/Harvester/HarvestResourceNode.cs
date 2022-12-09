using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Environment.Crops;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class HarvestResourceNode : BehaviorNode
    {
        private readonly ICollectable _resource;
        private readonly ICharacter _harvester;

        public HarvestResourceNode(ICollectable resource, ICharacter harvester)
        {
            _resource = resource;
            _harvester = harvester;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _harvester.Harvest(_resource);
            return BehaviorNodeStatus.Success;
        }
    }
}