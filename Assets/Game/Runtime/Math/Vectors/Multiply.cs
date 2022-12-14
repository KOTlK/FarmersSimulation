namespace Game.Runtime.Math.Vectors
{
    public class Multiply : Vector2Int
    {
        public Multiply(Vector2Int from, int multiplier) : base(from.X * multiplier, from.Y * multiplier)
        {
        }
    }
}