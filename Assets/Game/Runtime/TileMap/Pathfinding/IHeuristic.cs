using Game.Runtime.Math.Vectors;

namespace Game.Runtime.TileMap.Pathfinding
{
    public interface IHeuristic
    {
        float Value(Vector2Int first, Vector2Int second);
    }
}