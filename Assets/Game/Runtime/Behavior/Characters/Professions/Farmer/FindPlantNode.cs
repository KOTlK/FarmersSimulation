using BananaParty.BehaviorTree;
using Game.Runtime.Environment;
using Game.Runtime.Environment.Crops;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class FindPlantNode : BehaviorNode
    {
        private readonly IResourceStack<IPlant> _plants;
        private readonly IPlantSelector _plantSelector;

        public FindPlantNode(IResourceStack<IPlant> plants, IPlantSelector plantSelector)
        {
            _plants = plants;
            _plantSelector = plantSelector;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_plants.HasResource == false)
                return BehaviorNodeStatus.Failure;

            _plantSelector.Select(_plants.Pop());
            return BehaviorNodeStatus.Success;
        }
    }
}