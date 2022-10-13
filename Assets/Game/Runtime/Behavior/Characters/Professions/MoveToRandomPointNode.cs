using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.View;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public class MoveToRandomPointNode : BehaviorNode
    {
        private readonly RandomPointFromCharacter _randomPoint;
        private readonly ICharacter _character;

        public MoveToRandomPointNode(ICharacter character, float distance)
        {
            _randomPoint = new RandomPointFromCharacter(character, distance);
            _character = character;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            var direction = _randomPoint.Position - _character.Position;

            if (direction.sqrMagnitude <= 4f)
                return BehaviorNodeStatus.Success;

            _character.Move(direction.normalized);
            return BehaviorNodeStatus.Running;
        }

        public override void Reset()
        {
            base.Reset();
            _randomPoint.Next();
        }
    }
}