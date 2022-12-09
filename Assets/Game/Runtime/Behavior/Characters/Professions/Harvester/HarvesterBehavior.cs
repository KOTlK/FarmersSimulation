using BananaParty.BehaviorTree;
using Game.Runtime.Behavior.Characters.Professions.Harvester;
using Game.Runtime.Characters;
using Game.Runtime.Environment;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;
using Game.Runtime.View;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class HarvesterBehavior<TResource> : IBehavior
    where TResource : class, ISceneObject, ICollectable
    {
        private readonly IBehaviorNode _behavior;

        public HarvesterBehavior(ICharacter harvester, IResourceStack<TResource> stack, IWorldStorage storage)
        {
            var selector = new ResourceSelector<TResource>();

            _behavior = new SelectorNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new IsInventoryFullNode(harvester),
                    new FindResourceNode<TResource>(stack, selector),
                    new MoveTowardsNode(harvester, selector),
                    new WaitNode(1000),
                    new HarvestResourceNode(selector, harvester)
                }),
                
                new SequenceNode(new IBehaviorNode[]
                {
                    new HasResourceNode(harvester),
                    new MoveTowardsNode(harvester, storage),
                    new EmptyPocketsNode(storage, harvester)
                }),
                
                new ParallelSequenceNode(new IBehaviorNode[]
                {
                    new MoveToRandomPointNode(harvester, 10f),
                    new WaitNode(500)
                })
            }).Repeat();
        }

        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view) => _behavior.WriteToGraph(view);

        public void Execute(long time) => _behavior.Execute(time);
    }
}