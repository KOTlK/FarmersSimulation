using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Input;
using Game.Runtime.Input.Characters;

namespace Game.Runtime.Behavior.Session
{
    public class WaitCharacterClickNode : BehaviorNode
    {
        private readonly ISelectedCharacter _characterSelector;
        private readonly IClickQueue<ICharacter> _input;

        public WaitCharacterClickNode(ISelectedCharacter characterSelector, IClickQueue<ICharacter> input)
        {
            _characterSelector = characterSelector;
            _input = input;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_input.HasUnreadInput == false)
                return BehaviorNodeStatus.Running;

            _characterSelector.Add(_input.GetInput());
            return BehaviorNodeStatus.Success;
        }
    }
}