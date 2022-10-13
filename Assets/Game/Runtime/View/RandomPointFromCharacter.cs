using Game.Runtime.Characters;
using UnityEngine;

namespace Game.Runtime.View
{
    public class RandomPointFromCharacter : ISceneObject
    {
        private readonly ICharacter _character;
        private readonly float _distance;

        public RandomPointFromCharacter(ICharacter character, float distance)
        {
            _character = character;
            _distance = distance;
            Next();
        }

        public Vector2 Position { get; private set; }

        public void Next()
        {
            Position = _character.Position + Random.insideUnitCircle * _distance;
        }
    }
}