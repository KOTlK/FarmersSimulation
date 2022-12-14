namespace Game.Runtime.Math.Vectors
{
    public class Subtract : Vector2Int
    {
        public Subtract(Vector2Int from, Vector2Int target) : base(from.X - target.X, from.Y - target.Y)
        {
        }
    }
}