using BananaParty.BehaviorTree;
using Game.Runtime.Input;

namespace Game.Runtime.Behavior.Session.View
{
    public class ActivateElementNode : BehaviorNode
    {
        private readonly IElement _element;

        public ActivateElementNode(IElement element)
        {
            _element = element;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _element.IsActive = true;
            return BehaviorNodeStatus.Success;
        }
    }
}