using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.TileMap;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public class CivilianBehavior : BehaviorNode
    {
        private readonly IBehaviorNode _behavior;

        private const long WaitDuration = 5;

        public CivilianBehavior(ICharacter origin, ITileMap tileMap)
        {
            _behavior = new SequenceNode(
                new IBehaviorNode[]
                {
                    new SequenceNode(new IBehaviorNode[]
                        {
                            new MoveToRandomPointAround(origin, tileMap),
                            new WaitNode(WaitDuration)
                        }
                    ),
                }
            ).Repeat();
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