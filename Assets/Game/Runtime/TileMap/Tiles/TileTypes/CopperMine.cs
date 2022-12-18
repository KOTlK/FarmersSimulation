using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public class CopperMine : CollectableResource
    {
        public CopperMine(ITile origin) : base(origin) { }
        protected override Resource Resource => Resource.Copper;
        protected override int Cooldown => 3;

        public override void Visualize(ITileMapRenderer view)
        {
            base.Visualize(view);
            view.DisplayDecorator(Position, TileType.CopperMine);
        }
    }
}