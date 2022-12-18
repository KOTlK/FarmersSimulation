using Game.Runtime.Math.Vectors;

namespace Game.Runtime.TileMap.Pathfinding
{
    public interface IHeuristic
    {
        double Value(Vector2Int first, Vector2Int second);
    }
}