using Game.Runtime.Characters;
using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap.Tiles;

namespace Game.Runtime.View
{
    public class RandomPointFromCharacter : ITransform
    {
        private readonly ICharacter _character;
        private readonly int _distance;
        private readonly System.Random _random;
        
        public RandomPointFromCharacter(ICharacter character, int distance)
        {
            _character = character;
            _distance = distance;
            _random = new System.Random();
            Next();
        }

        public Vector2Int Position { get; private set; }

        private void Next()
        {
            Position = new Sum(
                _character.Position,
                new Multiply(new RandomDirection(_random), _distance));
        }
    }
}