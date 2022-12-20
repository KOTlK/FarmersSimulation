using Game.Runtime.Characters;
using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap.Tiles;

namespace Game.Runtime.View
{
    public class RandomPointFromCharacter : ITransform
    {
        private readonly ICharacter _character;
        private readonly int _distance;
        private readonly RandomDirection _randomDirection = new();
        
        public RandomPointFromCharacter(ICharacter character, int distance)
        {
            _character = character;
            _distance = distance;
            Next();
        }

        public Vector2Int Position { get; private set; }

        private void Next()
        {
            Position = _character.Position + _randomDirection.Next() * _distance;
        }
    }
}