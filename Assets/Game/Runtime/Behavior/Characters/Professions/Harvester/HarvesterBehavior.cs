using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Environment;
using Game.Runtime.TileMap;
using Game.Runtime.TileMap.Tiles.TileTypes;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class HarvesterBehavior : BehaviorNode
    {
        private readonly IBehaviorNode _behavior;

        public HarvesterBehavior(ICharacter harvester, IResourceStack<CollectableResource> stack, IChest storage, ITileMap tileMap)
        {
            var selector = new ResourceSelector<CollectableResource>();
            var path = new PathVariable();

            _behavior = new SelectorNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new IsInventoryFullNode(harvester),
                    new FindResourceNode<CollectableResource>(stack, selector),
                    new FindPathNode(path, tileMap, harvester, selector),
                    new MoveTowardsNode(harvester, path),
                    new WaitNode(2),
                    new HarvestResourceNode(selector, harvester)
                }),
                
                new SequenceNode(new IBehaviorNode[]
                {
                    new HasResourceNode(harvester),
                    new FindPathNode(path, tileMap, harvester, storage),
                    new MoveTowardsNode(harvester, path),
                    new EmptyPocketsNode(storage, harvester)
                }),
                
                new ParallelSequenceNode(new IBehaviorNode[]
                {
                    new MoveToRandomPointAround(harvester, tileMap),
                    new WaitNode(3)
                })
            }).Repeat();
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _behavior.Execute(time);
        }

        public override void WriteToGraph(ITreeGraph<IReadOnlyBehaviorNode> nodeGraph)
        {
            base.WriteToGraph(nodeGraph);
            _behavior.WriteToGraph(nodeGraph);
        }
    }
}