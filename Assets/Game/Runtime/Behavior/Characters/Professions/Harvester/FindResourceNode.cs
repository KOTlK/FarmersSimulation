using BananaParty.BehaviorTree;
using Game.Runtime.Environment;
using Game.Runtime.View;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class FindResourceNode<TResource> : BehaviorNode where TResource : ISceneObject
    {
        private readonly IResourceStack<TResource> _stack;
        private readonly IResourceSelector<TResource> _resourceSelector;

        public FindResourceNode(IResourceStack<TResource> stack, IResourceSelector<TResource> resourceSelector)
        {
            _stack = stack;
            _resourceSelector = resourceSelector;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_stack.HasResource == false)
                return BehaviorNodeStatus.Failure;

            _resourceSelector.Select(_stack.Pop());
            return BehaviorNodeStatus.Success;
        }
    }
}