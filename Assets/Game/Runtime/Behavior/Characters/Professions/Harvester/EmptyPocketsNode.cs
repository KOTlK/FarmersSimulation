using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Resources;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class EmptyPocketsNode : BehaviorNode
    {
        private readonly IResourceStorage _storage;
        private readonly ICharacter _farmer;

        public EmptyPocketsNode(IResourceStorage storage, ICharacter farmer)
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