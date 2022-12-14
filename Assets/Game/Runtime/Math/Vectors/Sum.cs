namespace Game.Runtime.Math.Vectors
{
    public class Sum : Vector2Int
    {
        public Sum(Vector2Int first, Vector2Int second) : base(first.X + second.X, first.Y + second.Y)
        {
        }
    }
}