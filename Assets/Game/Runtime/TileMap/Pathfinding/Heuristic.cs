using Game.Runtime.Math.Vectors;

namespace Game.Runtime.TileMap.Pathfinding
{
    public class Heuristic : IHeuristic
    {
        public float Value(Vector2Int first, Vector2Int second)
        {
            return System.Math.Abs(first.X - second.X) + System.Math.Abs(first.Y - second.Y);
        }
    }
}