using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap;

namespace Game.Runtime.Behavior.Characters
{
    public class MoveToRandomPointAround : BehaviorNode
    {
        private readonly ICharacter _origin;
        private readonly ITileMap _tileMap;
        
        private Vector2Int _direction;

        public MoveToRandomPointAround(ICharacter origin, ITileMap tileMap)
        {
            _origin = origin;
            _tileMap = tileMap;
            _direction = _tileMap.PointAround(origin.Position).Normalized;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _origin.Move(_direction);
            return BehaviorNodeStatus.Success;
        }

        public override void Reset()
        {
            base.Reset();
            _direction = _tileMap.PointAround(_origin.Position).Normalized;
        }
    }
}