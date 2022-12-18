using Game.Runtime.Math.Vectors;
using Game.Runtime.View;
using Game.Runtime.View.TileGraph;

namespace Game.Runtime.TileMap.Pathfinding
{
    public interface IPath : IVisualization<ITileGraphView>
    {
        Vector2Int Current { get; }
        bool Next();
    }
}