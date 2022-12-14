using BananaParty.BehaviorTree;
using Game.Runtime.DateTime;

namespace Game.Runtime.Behavior.Time
{
    public class CompareTimeNode : BehaviorNode
    {
        private readonly IDateTime _dateTime;
        private readonly int _hours;
        private readonly int _minutes;

        public CompareTimeNode(IDateTime dateTime, int hours, int minutes)
        {
            _dateTime = dateTime;
            _hours = hours;
            _minutes = minutes;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_dateTime.Time.Hours == _hours && _dateTime.Time.Minutes == _minutes)
                return BehaviorNodeStatus.Success;

            return BehaviorNodeStatus.Failure;
        }
    }
}