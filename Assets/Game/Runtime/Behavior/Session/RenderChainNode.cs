using System.Collections.Generic;
using BananaParty.BehaviorTree;
using Game.Runtime.View;

namespace Game.Runtime.Behavior.Session
{
    public class RenderChainNode<TModel, TView> : BehaviorNode
    where TModel : IVisualization<TView>
    {
        private readonly IEnumerable<RenderNode<TModel, TView>> _renders;

        public RenderChainNode(IEnumerable<RenderNode<TModel, TView>> renders)
        {
            _renders = renders;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            foreach (var render in _renders)
            {
                render.Execute(time);
            }

            return BehaviorNodeStatus.Success;
        }
    }
}