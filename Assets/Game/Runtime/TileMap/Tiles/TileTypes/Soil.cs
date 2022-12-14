using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Math.Vectors;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public class Soil : GroundCover
    {
        public Soil(Vector2Int position) : base(position)
        {
        }

        protected override TileType Visualization { get; } = TileType.Soil;
        public override bool Walkable { get; } = true;
    }
}