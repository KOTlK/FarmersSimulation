using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Math.Vectors;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public class Grass : GroundCover
    {
        public Grass(Vector2Int position) : base(position)
        {
        }

        protected override TileType Visualization { get; } = TileType.Grass;
        public override bool Walkable { get; } = true;
    }
}