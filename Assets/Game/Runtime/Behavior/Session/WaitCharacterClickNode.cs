using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Input;
using Game.Runtime.Input.Characters;

namespace Game.Runtime.Behavior.Session
{
    public class WaitCharacterClickNode : BehaviorNode
    {
        private readonly ICharacterSelector _characterSelectorSelector;
        private readonly IClickQueue<Runtime.Characters.ICharacter> _input;

        public WaitCharacterClickNode(ICharacterSelector characterSelectorSelector, IClickQueue<Runtime.Characters.ICharacter> input)
        {
            _characterSelectorSelector = characterSelectorSelector;
            _input = input;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_input.HasUnreadInput == false)
                return BehaviorNodeStatus.Running;

            _characterSelectorSelector.Select(_input.GetInput());
            return BehaviorNodeStatus.Success;
        }
    }
}