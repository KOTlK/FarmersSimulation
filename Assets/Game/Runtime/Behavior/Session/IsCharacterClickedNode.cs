using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Input;
using Game.Runtime.Input.Characters;

namespace Game.Runtime.Behavior.Session
{
    public class IsCharacterClickedNode : BehaviorNode
    {
        private readonly IClickQueue<Runtime.Characters.IFriendlyCharacter> _characterQueue;
        private readonly IFriendlyCharacterSelector _friendlyCharacterSelector;

        public IsCharacterClickedNode(IClickQueue<Runtime.Characters.IFriendlyCharacter> characterQueue, IFriendlyCharacterSelector friendlyCharacterSelector)
        {
            _characterQueue = characterQueue;
            _friendlyCharacterSelector = friendlyCharacterSelector;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_characterQueue.HasUnreadInput == false) return BehaviorNodeStatus.Failure;
            
            
            _friendlyCharacterSelector.Select(_characterQueue.GetInput());
            _characterQueue.Clear();
            return BehaviorNodeStatus.Success;

        }
    }
}