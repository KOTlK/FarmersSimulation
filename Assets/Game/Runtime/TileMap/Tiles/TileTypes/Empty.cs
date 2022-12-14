using Game.Runtime.Math.Vectors;
using Game.Runtime.Rendering.Tiles;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public class Empty : ITile
    {
        public Empty(Vector2Int position)
        {
            Position = position;
        }
        public Vector2Int Position { get; }
        public void Visualize(ITileMapRenderer view)
        {
            view.SwitchTileInPosition(Position, TileType.Empty);
        }
    }
}