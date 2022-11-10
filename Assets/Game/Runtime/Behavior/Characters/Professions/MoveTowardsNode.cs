using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.View;
using UnityEngine;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public class MoveTowardsNode : BehaviorNode
    {
        private readonly ICharacter _character;
        private readonly ISceneObject _target;

        public MoveTowardsNode(ICharacter character, ISceneObject target)
        {
            _character = character;
            _target = target;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            var direction = _target.Position - _character.Position;

            if (direction.sqrMagnitude <= 2f)
            {
                _character.Direction = Vector2.zero;
                return BehaviorNodeStatus.Success;
            }

            _character.Direction = direction.normalized;
            return BehaviorNodeStatus.Running;
        }
    }
}