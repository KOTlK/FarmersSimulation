using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.View;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public class MoveToNode : BehaviorNode
    {
        private readonly ICharacter _character;
        private readonly ISceneObject _target;

        public MoveToNode(ICharacter character, ISceneObject target)
        {
            _character = character;
            _target = target;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            var direction = _target.Position - _character.Position;

            if (direction.sqrMagnitude <= 2f)
                return BehaviorNodeStatus.Success;

            _character.Move(direction.normalized);
            return BehaviorNodeStatus.Running;
        }
    }
}