using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public class SilverMine : CollectableResource
    {
        public SilverMine(ITile origin) : base(origin) { }
        protected override Resource Resource { get; } = Resource.Silver;
        protected override int Cooldown { get; } = 5;

        public override void Visualize(ITileMapRenderer view)
        {
            base.Visualize(view);
            view.DisplayDecorator(Position, TileType.SilverMine);
        }
    }
}