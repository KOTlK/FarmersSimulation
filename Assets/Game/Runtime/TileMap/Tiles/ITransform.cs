using Game.Runtime.Math.Vectors;

namespace Game.Runtime.TileMap.Tiles
{
    public interface ITransform
    {
        Vector2Int Position { get; }
    }
}