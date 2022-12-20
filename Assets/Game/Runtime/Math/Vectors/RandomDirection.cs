namespace Game.Runtime.Math.Vectors
{
    public class RandomDirection
    {
        private readonly System.Random _random = new();

        public RandomDirection() { }

        public Vector2Int Next()
        {
            return new Vector2Int(_random.Next(-1, 1), _random.Next(-1, 1));
        }
    }
}