using BananaParty.BehaviorTree;
using Game.Runtime.Input;

namespace Game.Runtime.Behavior.Session
{
    public class IsElementClickedNode<T> : BehaviorNode
    {
        private readonly IClickQueue<T> _queue;

        public IsElementClickedNode(IClickQueue<T> queue)
        {
            _queue = queue;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_queue.HasUnreadInput == false)
                return BehaviorNodeStatus.Failure;

            _queue.Clear();
            return BehaviorNodeStatus.Success;
        }
    }
}