using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.View;
using UnityEngine;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public class MoveToRandomPointNode : BehaviorNode
    {
        private readonly RandomPointFromCharacter _randomPoint;
        private readonly IFriendlyCharacter _friendlyCharacter;

        public MoveToRandomPointNode(IFriendlyCharacter friendlyCharacter, float distance)
        {
            _randomPoint = new RandomPointFromCharacter(friendlyCharacter, distance);
            _friendlyCharacter = friendlyCharacter;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            var direction = _randomPoint.Position - _friendlyCharacter.Position;

            if (direction.sqrMagnitude <= 4f)
            {
                _friendlyCharacter.Direction = Vector2.zero;
                return BehaviorNodeStatus.Success;
            }

            _friendlyCharacter.Direction = direction.normalized;
            return BehaviorNodeStatus.Running;
        }

        public override void Reset()
        {
            base.Reset();
            _randomPoint.Next();
        }
    }
}