using BananaParty.BehaviorTree;
using Game.Runtime.Characters.Professions.Farmer;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class FarmerBehavior : IBehavior
    {
        private readonly IBehaviorNode _behavior;

        public FarmerBehavior(IFarmer farmer, IGrownPlants grownPlants, IWorldStorage storage)
        {
            var targetPlant = new TargetPlant();
            
            _behavior = new SelectorNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new IsInventoryFullNode(farmer),
                    new FindWheatNode(grownPlants, targetPlant),
                    new MoveToNode(farmer, targetPlant),
                    new WaitNode(1000),
                    new GatherWheatNode(targetPlant, farmer)
                }),
                
                new SequenceNode(new IBehaviorNode[]
                {
                    new HasWheatNode(farmer),
                    new MoveToNode(farmer, storage),
                    new EmptyPocketsNode(storage, farmer)
                }),
                
                new SequenceNode(new IBehaviorNode[]
                {
                    new MoveToRandomPointNode(farmer, 10f),
                    new WaitNode(500)
                })
            }).Repeat();
        }

        public void ExecuteBehavior(long time)
        {
            _behavior.Execute(time);
        }

        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> graph)
        {
            _behavior.WriteToGraph(graph);
        }
    }
}