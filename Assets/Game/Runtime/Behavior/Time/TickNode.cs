using BananaParty.BehaviorTree;
using Game.Game.Runtime.DateTime;

namespace Game.Runtime.Behavior.Time
{
    public class TickNode : BehaviorNode
    {
        private readonly IDateTime _dateTime;

        public TickNode(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _dateTime.Tick();
            return BehaviorNodeStatus.Success;
        }
    }
}