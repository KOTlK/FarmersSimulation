using Game.Runtime.Math.Vectors;
using Game.Runtime.Rendering.Tiles;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public abstract class Decorator : ITile
    {
        public ITile Origin { get; }

        protected Decorator(ITile origin)
        {
            Origin = origin;
            Position = Origin.Position;
        }
        public Vector2Int Position { get; }
        public virtual void Visualize(ITileMapRenderer view)
        {
            Origin.Visualize(view);
        }
    }
}