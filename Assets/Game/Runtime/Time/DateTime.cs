using Game.Runtime.View.DateTime;

namespace Game.Runtime.DateTime
{
    public class DateTime : IDateTime
    {
        public DateTime(IDate date, ITime time)
        {
            Date = date;
            Time = time;
        }

        public IDate Date { get; }
        public ITime Time { get; }
        
        public void Tick()
        {
            Time.NextMinute();
            if (Time.Hours != 0) return;
            if (Time.Minutes != 0) return;
            Date.NextDay();
        }

        public void Visualize(IDateView view) => Date.Visualize(view);
        public void Visualize(ITimeView view) => Time.Visualize(view);
    }
}