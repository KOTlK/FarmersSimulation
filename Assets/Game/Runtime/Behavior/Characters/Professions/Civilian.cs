using BananaParty.BehaviorTree;
using Game.Runtime.Characters;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public class Civilian : IBehavior
    {
        private readonly IBehaviorNode _behavior;

        private const long WalkDuration = 2000;
        private const long WaitDuration = 2000;

        public Civilian(IMovement origin)
        {
            _behavior = new SequenceNode(
                new IBehaviorNode[]
                {
                    new ParallelSelectorNode(new IBehaviorNode[]
                        {
                            new MoveToRandomDirectionNode(origin),
                            new WaitNode(WalkDuration)
                        }
                    ),
                    new WaitNode(WaitDuration)
                }
            ).Repeat();
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