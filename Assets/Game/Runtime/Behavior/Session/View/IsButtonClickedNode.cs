using BananaParty.BehaviorTree;
using Game.Runtime.Input.View;

namespace Game.Runtime.Behavior.Session.View
{
    public class IsButtonClickedNode : BehaviorNode
    {
        private readonly IButton _button;

        public IsButtonClickedNode(IButton button)
        {
            _button = button;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_button.Clicked == false)
                return BehaviorNodeStatus.Failure;

            _button.Reset();
            return BehaviorNodeStatus.Success;
        }

    }
}