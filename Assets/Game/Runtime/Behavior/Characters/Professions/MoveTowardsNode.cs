using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap.Pathfinding;
using Game.Runtime.TileMap.Tiles;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public class MoveTowardsNode : BehaviorNode
    {
        private readonly ICharacter _character;
        private readonly ITransform _target;
        private readonly IAlgorithm _pathfinding;

        public MoveTowardsNode(ICharacter character, ITransform target, IAlgorithm pathfinding)
        {
            _character = character;
            _target = target;
            _pathfinding = pathfinding;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            var path = _pathfinding.FindPath(_character.Position, _target.Position);
            path.Next();
            
            if (path.Next())
            {
                var direction = new Subtract(path.Current, _character.Position);
                _character.Move(direction);
                return BehaviorNodeStatus.Running;
            }

            return BehaviorNodeStatus.Success;
        }

    }
}