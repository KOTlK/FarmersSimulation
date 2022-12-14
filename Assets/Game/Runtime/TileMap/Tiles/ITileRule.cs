using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Math.Vectors;

namespace Game.Runtime.TileMap.Tiles
{
    public interface ITileRule
    {
        ITile Next(Vector2Int position);
    }
}