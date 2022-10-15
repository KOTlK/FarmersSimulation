namespace Game.Runtime.Random
{
    public class RandomName : IRandomGenerator<string>
    {
        private readonly string[] _names;
        private readonly System.Random _random;

        public RandomName(string names)
        {
            _names = names.Split("\n");
            _random = new System.Random();
        }

        public string Next()
        {
            return _names[_random.Next(0, _names.Length)];
        }
    }
}