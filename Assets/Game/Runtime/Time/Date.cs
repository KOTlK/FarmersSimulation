using Game.Runtime.View.DateTime;

namespace Game.Runtime.DateTime
{
    public class Date : IDate
    {
        /// <summary>
        /// Month.Day.Year
        /// </summary>
        public Date(int month, int day, int year)
        {
            Day = day;
            Year = year;
            Month = month;
        }

        public int Day { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }

        public void NextDay()
        {
            Day++;
            if (Day <= 31) return;
            Month++;
            Day = 1;
            if (Month <= 12) return;
            Year++;
            Month = 1;
        }

        public void Visualize(IDateView view)
        {
            view.DisplayDate(Month, Day, Year);
        }
    }
}