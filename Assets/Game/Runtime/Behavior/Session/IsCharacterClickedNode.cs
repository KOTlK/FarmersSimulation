using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Input;
using Game.Runtime.Input.Characters;

namespace Game.Runtime.Behavior.Session
{
    public class IsCharacterClickedNode : BehaviorNode
    {
        private readonly IClickQueue<Runtime.Characters.ICharacter> _characterQueue;
        private readonly ICharacterSelector _characterSelector;

        public IsCharacterClickedNode(IClickQueue<Runtime.Characters.ICharacter> characterQueue, ICharacterSelector characterSelector)
        {
            _characterQueue = characterQueue;
            _characterSelector = characterSelector;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_characterQueue.HasUnreadInput == false) return BehaviorNodeStatus.Failure;
            
            
            _characterSelector.Select(_characterQueue.GetInput());
            _characterQueue.Clear();
            return BehaviorNodeStatus.Success;

        }
    }
}