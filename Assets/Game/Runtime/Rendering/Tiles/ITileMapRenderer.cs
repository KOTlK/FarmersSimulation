using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Math.Vectors;

namespace Game.Runtime.Rendering.Tiles
{
    public interface ITileMapRenderer
    {
        void SwitchTileInPosition(Vector2Int position, TileType type);
        void DisplayDecorator(Vector2Int position, TileType type);
    }
}