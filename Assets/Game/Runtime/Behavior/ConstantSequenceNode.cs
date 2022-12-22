using BananaParty.BehaviorTree;

namespace Game.Runtime.Behavior
{
    public class ConstantSequenceNode : BehaviorNode
    {
        private readonly IBehaviorNode[] _nodes;
        private readonly BehaviorNodeStatus _status;

        public ConstantSequenceNode(IBehaviorNode[] nodes, BehaviorNodeStatus status)
        {
            _nodes = nodes;
            _status = status;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            foreach (var node in _nodes)
            {
                node.Execute(time);
            }

            return _status;
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