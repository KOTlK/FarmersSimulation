using Game.Runtime.View;
using Game.Runtime.View.DateTime;

namespace Game.Runtime.DateTime
{
    public interface ITime : IVisualization<ITimeView>
    {
        public int Minutes { get; }
        public int Hours { get; }
        void NextMinute();
    }
}