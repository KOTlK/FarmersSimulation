namespace Game.Runtime.Random
{
    public class RandomAge : IRandomGenerator<float>
    {
        private readonly float _max;
        private readonly float _min;

        public RandomAge(float max, float min)
        {
            _max = max;
            _min = min;
        }

        public float Next()
        {
            return UnityEngine.Random.Range(_min, _max);
        }
    }
}