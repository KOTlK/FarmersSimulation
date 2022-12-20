using BananaParty.BehaviorTree;
using Game.Runtime.TileMap.Pathfinding;
using Game.Runtime.TileMap.Tiles;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class FindPathNode : BehaviorNode
    {
        private readonly PathVariable _path;
        private readonly IAlgorithm _pathfinding;
        private readonly ITransform _from;
        private readonly ITransform _to;

        public FindPathNode(PathVariable path, IAlgorithm pathfinding, ITransform @from, ITransform to)
        {
            _path = path;
            _pathfinding = pathfinding;
            _from = @from;
            _to = to;
        }


        public override BehaviorNodeStatus OnExecute(long time)
        {
            _path.Path = _pathfinding.FindPath(_from.Position, _to.Position);

            return BehaviorNodeStatus.Success;
        }
    }
}