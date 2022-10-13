using BananaParty.BehaviorTree;
using Game.Runtime.Environment.Crops;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class FindWheatNode : BehaviorNode
    {
        private readonly IGrownPlants _plants;
        private readonly ITargetPlant _targetPlant;

        public FindWheatNode(IGrownPlants plants, ITargetPlant targetPlant)
        {
            _plants = plants;
            _targetPlant = targetPlant;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_plants.HasGrownPlants() == false)
                return BehaviorNodeStatus.Failure;

            _targetPlant.NewTarget(_plants.GetPlant());
            return BehaviorNodeStatus.Success;
        }
    }
}