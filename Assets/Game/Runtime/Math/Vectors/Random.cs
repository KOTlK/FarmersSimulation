namespace Game.Runtime.Math.Vectors
{
    public class Random : Vector2Int
    {
        public Random(System.Random random, Range range)
            : base(random.Next(range.MinX, range.MaxX), random.Next(range.MinY, range.MaxY))
        {
        }
    }
}