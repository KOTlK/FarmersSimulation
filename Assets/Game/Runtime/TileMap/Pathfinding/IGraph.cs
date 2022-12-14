using System.Collections.Generic;
using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.View;
using Game.Runtime.View.TileGraph;

namespace Game.Runtime.TileMap.Pathfinding
{
    public interface IGraph : IVisualization<ITileGraphView>
    {
        IEnumerable<Vector2Int> Neighbours(Vector2Int nodePosition);
        void Recalculate(Vector2Int position, ITile tile);
        double Cost(Vector2Int from, Vector2Int to);
    }
}