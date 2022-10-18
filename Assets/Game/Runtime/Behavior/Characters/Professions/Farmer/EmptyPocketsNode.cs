using BananaParty.BehaviorTree;
using Game.Runtime.Characters.Professions.Farmer;
using Game.Runtime.Resources;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class EmptyPocketsNode : BehaviorNode
    {
        private readonly IWorldStorage _storage;
        private readonly IFarmer _farmer;

        public EmptyPocketsNode(IWorldStorage storage, IFarmer farmer)
        {
            _storage = storage;
            _farmer = farmer;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _farmer.EmptyPockets(_storage);
            return BehaviorNodeStatus.Success;
        }
    }
}