using Game.Runtime.View.DateTime;

namespace Game.Runtime.DateTime
{
    public class Time : ITime
    {
        private readonly int _timeStep;
        
        public Time(int minutes, int hours, int timeStep)
        {
            Minutes = minutes;
            Hours = hours;
            _timeStep = timeStep;
        }

        public int Minutes { get; private set; }
        public int Hours { get; private set; }
        
        public void NextMinute()
        {
            Minutes += _timeStep;
            if (Minutes <= 50) return;
            Minutes = 0;
            Hours++;
            if (Hours <= 23) return;
            Hours = 0;
        }

        public void Visualize(ITimeView view)
        {
            view.DisplayTime(Minutes, Hours);
        }
    }
}