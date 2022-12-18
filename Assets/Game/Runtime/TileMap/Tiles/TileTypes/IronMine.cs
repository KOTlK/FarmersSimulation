using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public class IronMine : CollectableResource
    {
        public IronMine(ITile origin) : base(origin) { }
        protected override Resource Resource { get; } = Resource.Iron;
        protected override int Cooldown { get; } = 4;

        public override void Visualize(ITileMapRenderer view)
        {
            base.Visualize(view);
            view.DisplayDecorator(Position, TileType.IronMine);
        }
    }
}