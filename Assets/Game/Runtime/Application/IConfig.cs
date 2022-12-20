using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap.Pathfinding;

namespace Game.Runtime.Application
{
    public interface IConfig
    {
        string Names { get; }
        Vector2Int TileMapSize { get; }
        Vector2Int TileMapNoiseOffset { get; }
        float TileMapNoiseScale { get; }
        TilesCosts TilesCosts { get; }
    }
}