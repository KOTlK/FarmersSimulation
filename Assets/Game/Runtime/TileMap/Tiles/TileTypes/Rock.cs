using Game.Runtime.Math.Vectors;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public class Rock : GroundCover
    {
        public Rock(Vector2Int position) : base(position)
        {
        }

        protected override TileType Visualization { get; } = TileType.Rock;
    }
}