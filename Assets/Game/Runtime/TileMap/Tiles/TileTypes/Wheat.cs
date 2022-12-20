using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public sealed class Wheat : CollectableResource
    {
        public Wheat(ITile origin) : base(origin) { }
        protected override Resource Resource => Resource.Wheat;
        protected override int Cooldown => 100;
        
        public override void Visualize(ITileMapRenderer view)
        {
            base.Visualize(view);
            
            view.DisplayDecorator(
                Position,
                ReadyForGather switch
                {
                    true => TileType.WheatGrown,
                    false => TileType.WheatUndergrown
                }
            );
        }
    }
}