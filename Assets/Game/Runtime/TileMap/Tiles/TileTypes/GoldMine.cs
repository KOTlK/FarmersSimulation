using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public class GoldMine : CollectableResource
    {
        public GoldMine(ITile origin) : base(origin) { }
        protected override Resource Resource { get; } = Resource.Gold;
        protected override int Cooldown { get; } = 6;

        public override void Visualize(ITileMapRenderer view)
        {
            base.Visualize(view);
            view.DisplayDecorator(Position, TileType.GoldMine);
        }
    }
}