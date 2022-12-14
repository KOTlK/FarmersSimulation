using BananaParty.BehaviorTree;
using Game.Runtime.Factories;

namespace Game.Runtime.Behavior.Factories
{
    public class ProduceItemNode<TItem> : BehaviorNode
    {
        private readonly IFactory<TItem> _factory;

        public ProduceItemNode(IFactory<TItem> factory)
        {
            _factory = factory;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _factory.Create();
            return BehaviorNodeStatus.Success;
        }
    }
}