using BananaParty.BehaviorTree;
using Game.Runtime.Input.View;

namespace Game.Runtime.Behavior.Session.View
{
    public class WaitButtonClickNode : BehaviorNode
    {
        private readonly IButton _button;

        public WaitButtonClickNode(IButton button)
        {
            _button = button;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (Status == BehaviorNodeStatus.Success)
                return BehaviorNodeStatus.Success;

            if (_button.Clicked)
            {
                _button.Reset();
                return BehaviorNodeStatus.Success;
            }

            return BehaviorNodeStatus.Running;
        }
    }
}