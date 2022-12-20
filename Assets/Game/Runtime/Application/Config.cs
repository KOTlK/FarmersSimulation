using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap.Pathfinding;

namespace Game.Runtime.Application
{
    public class Config : IConfig
    {
        public Config(string names, Vector2Int tileMapSize, Vector2Int tileMapNoiseOffset, float tileMapNoiseScale, TilesCosts tilesCosts)
        {
            Names = names;
            TileMapSize = tileMapSize;
            TileMapNoiseOffset = tileMapNoiseOffset;
            TileMapNoiseScale = tileMapNoiseScale;
            TilesCosts = tilesCosts;
        }
        public string Names { get; }
        public Vector2Int TileMapSize { get; }
        public Vector2Int TileMapNoiseOffset { get; }
        public float TileMapNoiseScale { get; }
        public TilesCosts TilesCosts { get; }
    }
}