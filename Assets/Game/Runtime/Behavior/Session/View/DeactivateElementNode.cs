using BananaParty.BehaviorTree;
using Game.Runtime.Input;

namespace Game.Runtime.Behavior.Session.View
{
    public class DeactivateElementNode : BehaviorNode
    {
        private readonly IElement _element;

        public DeactivateElementNode(IElement element)
        {
            _element = element;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _element.IsActive = false;
            return BehaviorNodeStatus.Success;
        }
    }
}