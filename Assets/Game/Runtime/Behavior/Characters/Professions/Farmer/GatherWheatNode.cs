using BananaParty.BehaviorTree;
using Game.Runtime.Characters.Professions.Farmer;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class GatherWheatNode : BehaviorNode
    {
        private readonly IPlantSelector _plantSelector;
        private readonly IFarmer _farmer;

        public GatherWheatNode(IPlantSelector plantSelector, IFarmer farmer)
        {
            _plantSelector = plantSelector;
            _farmer = farmer;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _farmer.Harvest(_plantSelector);
            return BehaviorNodeStatus.Success;
        }
    }
}