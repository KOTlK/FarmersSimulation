using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Input.Characters;

namespace Game.Runtime.Behavior.Session
{
    public class IsCharacterClickedNode : BehaviorNode
    {
        private readonly IClickInputs<ICharacter> _characterInputs;
        private readonly IClickedCharacter _clickedCharacter;

        public IsCharacterClickedNode(IClickInputs<ICharacter> characterInputs, IClickedCharacter clickedCharacter)
        {
            _characterInputs = characterInputs;
            _clickedCharacter = clickedCharacter;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_characterInputs.HasUnreadInput == false) return BehaviorNodeStatus.Failure;
            
            
            _clickedCharacter.Add(_characterInputs.GetInput());
            _characterInputs.Clear();
            return BehaviorNodeStatus.Success;

        }
    }
}