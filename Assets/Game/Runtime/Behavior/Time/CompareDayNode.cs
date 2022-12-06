using BananaParty.BehaviorTree;
using Game.Game.Runtime.DateTime;

namespace Game.Runtime.Behavior.Time
{
    public class CompareDayNode : BehaviorNode
    {
        private readonly IDateTime _dateTime;
        private readonly int _day;

        public CompareDayNode(IDateTime dateTime, int day)
        {
            _dateTime = dateTime;
            _day = day;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_dateTime.Date.Day == _day)
                return BehaviorNodeStatus.Success;

            return BehaviorNodeStatus.Failure;
        }
    }
}