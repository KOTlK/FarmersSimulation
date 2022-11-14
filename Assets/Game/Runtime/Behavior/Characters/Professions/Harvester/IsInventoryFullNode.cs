using BananaParty.BehaviorTree;
using Game.Runtime.Characters.Professions.Farmer;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class IsInventoryFullNode : BehaviorNode
    {
        private readonly IHarvester _harvester;

        public IsInventoryFullNode(IHarvester harvester)
        {
            _harvester = harvester;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _harvester.InventoryFull ? 
                BehaviorNodeStatus.Failure : 
                BehaviorNodeStatus.Success;
        }
    }
}