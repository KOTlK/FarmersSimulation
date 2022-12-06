using Game.Runtime.View;
using Game.Runtime.View.DateTime;

namespace Game.Game.Runtime.DateTime
{
    public interface IDateTime : ITick, IVisualization<IDateView>, IVisualization<ITimeView>
    {
        IDate Date { get; }
        ITime Time { get; }
    }
}