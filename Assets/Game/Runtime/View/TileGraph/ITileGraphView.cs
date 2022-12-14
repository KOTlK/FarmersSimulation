using Game.Runtime.Math.Vectors;

namespace Game.Runtime.View.TileGraph
{
    public interface ITileGraphView
    {
        void DisplayDirection(Vector2Int from, Vector2Int to);
    }
}