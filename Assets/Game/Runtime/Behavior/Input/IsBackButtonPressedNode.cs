using BananaParty.BehaviorTree;
using Game.Runtime.Input.Player;

namespace Game.Runtime.Behavior.Input
{
    public class IsBackButtonPressedNode : BehaviorNode
    {
        private readonly IPlayerInput _input;

        public IsBackButtonPressedNode(IPlayerInput input)
        {
            _input = input;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_input.BackButtonPressed)
                return BehaviorNodeStatus.Success;

            return BehaviorNodeStatus.Failure;
        }
    }
}