using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Input;
using Game.Runtime.Input.Characters;

namespace Game.Runtime.Behavior.Session
{
    public class IsCharacterClickedNode : BehaviorNode
    {
        private readonly IClickQueue<ICharacter> _characterQueue;
        private readonly ISelectedCharacter _selectedCharacter;

        public IsCharacterClickedNode(IClickQueue<ICharacter> characterQueue, ISelectedCharacter selectedCharacter)
        {
            _characterQueue = characterQueue;
            _selectedCharacter = selectedCharacter;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_characterQueue.HasUnreadInput == false) return BehaviorNodeStatus.Failure;
            
            
            _selectedCharacter.Add(_characterQueue.GetInput());
            _characterQueue.Clear();
            return BehaviorNodeStatus.Success;

        }
    }
}