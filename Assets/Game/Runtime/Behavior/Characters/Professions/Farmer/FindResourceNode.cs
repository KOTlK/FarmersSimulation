using BananaParty.BehaviorTree;
using Game.Runtime.Environment;
using Game.Runtime.Input;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class FindResourceNode<TResource> : BehaviorNode
    {
        private readonly IResourceStack<TResource> _stack;
        private readonly IElementSelector<TResource> _selector;

        public FindResourceNode(IResourceStack<TResource> stack, IElementSelector<TResource> selector)
        {
            _stack = stack;
            _selector = selector;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_stack.HasResource == false)
                return BehaviorNodeStatus.Failure;

            _selector.Select(_stack.Pop());
            return BehaviorNodeStatus.Success;
        }
    }
}