using BananaParty.BehaviorTree;

namespace Game.Runtime.Behavior.Characters
{
    public class CombinedBehaviors : BehaviorNode
    {
        private readonly IBehaviorNode[] _nodes;

        public CombinedBehaviors(IBehaviorNode[] nodes)
        {
            _nodes = nodes;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            foreach (var node in _nodes)
            {
                node.Execute(time);
            }

            return BehaviorNodeStatus.Success;
        }

        public override void WriteToGraph(ITreeGraph<IReadOnlyBehaviorNode> nodeGraph)
        {
            base.WriteToGraph(nodeGraph);
            nodeGraph.StartChildGroup(_nodes.Length);
            foreach (var node in _nodes)
            {
                node.WriteToGraph(nodeGraph);
            }
            nodeGraph.EndChildGroup();
        }
    }
}