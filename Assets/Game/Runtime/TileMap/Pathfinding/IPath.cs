using System.Collections.Generic;
using Game.Runtime.Math.Vectors;
using Game.Runtime.View;
using Game.Runtime.View.TileGraph;

namespace Game.Runtime.TileMap.Pathfinding
{
    public interface IPath : IEnumerable<Vector2Int>, IVisualization<ITileGraphView>
    {
    }
}