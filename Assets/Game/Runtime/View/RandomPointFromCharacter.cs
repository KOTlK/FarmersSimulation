using Game.Runtime.Characters;
using UnityEngine;

namespace Game.Runtime.View
{
    public class RandomPointFromCharacter : ISceneObject
    {
        private readonly IFriendlyCharacter _friendlyCharacter;
        private readonly float _distance;

        public RandomPointFromCharacter(IFriendlyCharacter friendlyCharacter, float distance)
        {
            _friendlyCharacter = friendlyCharacter;
            _distance = distance;
            Next();
        }

        public Vector2 Position { get; private set; }

        public void Next()
        {
            Position = _friendlyCharacter.Position + UnityEngine.Random.insideUnitCircle * _distance;
        }
    }
}