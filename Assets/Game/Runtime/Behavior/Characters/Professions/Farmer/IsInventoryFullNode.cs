using BananaParty.BehaviorTree;
using Game.Runtime.Characters.Professions.Farmer;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class IsInventoryFullNode : BehaviorNode
    {
        private readonly IFarmer _farmer;

        public IsInventoryFullNode(IFarmer farmer)
        {
            _farmer = farmer;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_farmer.InventoryFull)
                return BehaviorNodeStatus.Failure;
            
            return BehaviorNodeStatus.Success;
        }
    }
}