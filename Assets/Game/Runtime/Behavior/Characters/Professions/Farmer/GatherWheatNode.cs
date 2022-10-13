using BananaParty.BehaviorTree;
using Game.Runtime.Characters.Professions.Farmer;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class GatherWheatNode : BehaviorNode
    {
        private readonly ITargetPlant _plant;
        private readonly IFarmer _farmer;

        public GatherWheatNode(ITargetPlant plant, IFarmer farmer)
        {
            _plant = plant;
            _farmer = farmer;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _farmer.GatherPlant(_plant);
            return BehaviorNodeStatus.Success;
        }
    }
}