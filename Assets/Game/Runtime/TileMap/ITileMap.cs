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
        void Replace(Vector2Int position, ITile tile);
    }
}