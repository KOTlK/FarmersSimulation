using BananaParty.BehaviorTree;
using Game.Runtime.Characters.Professions.Farmer;
using Game.Runtime.Environment;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class FarmerBehavior : IBehavior
    {
        private readonly IBehaviorNode _behavior;

        public FarmerBehavior(IFarmer farmer, IResourceStack<IPlant> grownPlants, IWorldStorage storage)
        {
            var targetPlant = new PlantSelector();
            
            _behavior = new SelectorNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new IsInventoryFullNode(farmer),
                    new FindResourceNode<IPlant>(grownPlants, targetPlant),
                    new MoveTowardsNode(farmer, targetPlant),
                    new WaitNode(1000),
                    new HarvestResourceNode(targetPlant, farmer)
                }),
                
                new SequenceNode(new IBehaviorNode[]
                {
                    new HasWheatNode(farmer),
                    new MoveTowardsNode(farmer, storage),
                    new EmptyPocketsNode(storage, farmer)
                }),
                
                new SequenceNode(new IBehaviorNode[]
                {
                    new MoveToRandomPointNode(farmer, 10f),
                    new WaitNode(500)
                })
            }).Repeat();
        }

        public void Execute(long time)
        {
            _behavior.Execute(time);
        }

        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> graph)
        {
            _behavior.WriteToGraph(graph);
        }
    }
}