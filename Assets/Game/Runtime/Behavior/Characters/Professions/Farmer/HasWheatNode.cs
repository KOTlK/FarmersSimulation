using BananaParty.BehaviorTree;
using Game.Runtime.Characters.Professions.Farmer;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class HasWheatNode : BehaviorNode
    {
        private readonly IFarmer _farmer;

        public HasWheatNode(IFarmer farmer)
        {
            _farmer = farmer;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _farmer.HasCollectedPlants ? 
                BehaviorNodeStatus.Success : 
                BehaviorNodeStatus.Failure;
        }
    }
}