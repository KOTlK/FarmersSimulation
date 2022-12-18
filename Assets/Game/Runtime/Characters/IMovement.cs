using Game.Runtime.Math.Vectors;

namespace Game.Runtime.Characters
{
    public interface IMovement
    {
        void Move(Vector2Int direction);
    }
}