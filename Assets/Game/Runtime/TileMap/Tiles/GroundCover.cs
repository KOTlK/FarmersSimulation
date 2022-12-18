using Game.Runtime.Math.Vectors;
using Game.Runtime.Rendering.Tiles;

namespace Game.Runtime.TileMap.Tiles
{
    public abstract class GroundCover : ITile
    {
        protected GroundCover(Vector2Int position)
        {
            Position = position;
        }
        protected abstract TileType Visualization { get; }
        public Vector2Int Position { get; }

        public void Visualize(ITileMapRenderer view)
        {
            view.SwitchTileInPosition(Position, Visualization);
        }
    }
}