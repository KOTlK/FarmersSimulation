namespace Game.Runtime.Math.Vectors
{
    public class RandomDirection : Vector2Int
    {
        public RandomDirection(System.Random random) : base(random.Next(-1, 1), random.Next(-1, 1)) { }
    }
}