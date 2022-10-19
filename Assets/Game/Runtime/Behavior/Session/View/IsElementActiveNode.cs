using BananaParty.BehaviorTree;
using Game.Runtime.Input;

namespace Game.Runtime.Behavior.Session.View
{
    public class IsElementActiveNode : BehaviorNode
    {
        private readonly IElement _element;

        public IsElementActiveNode(IElement element)
        {
            _element = element;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _element.IsActive ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}