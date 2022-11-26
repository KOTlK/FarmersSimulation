using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.View;
using UnityEngine;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public class MoveTowardsNode : BehaviorNode
    {
        private readonly IFriendlyCharacter _friendlyCharacter;
        private readonly ISceneObject _target;

        public MoveTowardsNode(IFriendlyCharacter friendlyCharacter, ISceneObject target)
        {
            _friendlyCharacter = friendlyCharacter;
            _target = target;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            var direction = _target.Position - _friendlyCharacter.Position;

            if (direction.sqrMagnitude <= 2f)
            {
                _friendlyCharacter.Direction = Vector2.zero;
                return BehaviorNodeStatus.Success;
            }

            _friendlyCharacter.Direction = direction.normalized;
            return BehaviorNodeStatus.Running;
        }
    }
}