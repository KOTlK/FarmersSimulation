using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Math.Vectors;

namespace Game.Runtime.View.Field
{
    public interface ITileView
    {
        TileType TileType { get; }
        void DisplayTile(Vector2Int position);
        void Destroy();
    }
}