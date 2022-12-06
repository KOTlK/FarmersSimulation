using Game.Runtime.View;
using Game.Runtime.View.DateTime;

namespace Game.Game.Runtime.DateTime
{
    public interface IDate : IVisualization<IDateView>
    {
        int Day { get; }
        int Month { get; }
        int Year { get; }
        void NextDay();
    }
}