using Game.Runtime.Math.Vectors;

namespace Game.Runtime.TileMap.Pathfinding
{
    public interface IAlgorithm
    {
        IPath FindPath(Vector2Int from, Vector2Int to);
    }
}