using BananaParty.BehaviorTree;
using Game.Runtime.Characters;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class IsInventoryFullNode : BehaviorNode
    {
        private readonly ICharacter _harvester;

        public IsInventoryFullNode(ICharacter harvester)
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