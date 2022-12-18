using Game.Runtime.Rendering.Tiles;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public class FactoryPart : Decorator
    {
        private readonly TileType _part;

        public FactoryPart(ITile origin, TileType part) : base(origin)
        {
            _part = part;
        }

        public override void Visualize(ITileMapRenderer view)
        {
            view.DisplayDecorator(Position, _part);
        }
    }
}