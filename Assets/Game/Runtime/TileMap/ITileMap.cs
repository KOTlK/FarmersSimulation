using System.Collections.Generic;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Math.Vectors;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Session;
using Game.Runtime.TileMap.Pathfinding;
using Game.Runtime.View;
using Game.Runtime.View.TileGraph;

namespace Game.Runtime.TileMap
{
    public interface ITileMap : IGameLoop, IVisualization<ITileMapRenderer>, IVisualization<ITileGraphView>, IAlgorithm
    {
        Vector2Int Size { get; }
        ITile this[Vector2Int position] { get; }
        bool Contains(Vector2Int position);
        Vector2Int PointAround(Vector2Int position);
        void Replace(Vector2Int position, ITile tile);
        IEnumerable<T> GetTiles<T>();
    }
}