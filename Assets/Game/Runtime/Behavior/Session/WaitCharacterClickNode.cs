using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Input;
using Game.Runtime.Input.Characters;

namespace Game.Runtime.Behavior.Session
{
    public class WaitCharacterClickNode : BehaviorNode
    {
        private readonly IFriendlyCharacterSelector _friendlyCharacterSelectorSelector;
        private readonly IClickQueue<Runtime.Characters.IFriendlyCharacter> _input;

        public WaitCharacterClickNode(IFriendlyCharacterSelector friendlyCharacterSelectorSelector, IClickQueue<Runtime.Characters.IFriendlyCharacter> input)
        {
            _friendlyCharacterSelectorSelector = friendlyCharacterSelectorSelector;
            _input = input;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_input.HasUnreadInput == false)
                return BehaviorNodeStatus.Running;

            _friendlyCharacterSelectorSelector.Select(_input.GetInput());
            return BehaviorNodeStatus.Success;
        }
    }
}