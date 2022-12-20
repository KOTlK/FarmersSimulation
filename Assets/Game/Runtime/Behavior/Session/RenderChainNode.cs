using System.Collections.Generic;
using BananaParty.BehaviorTree;
using Game.Runtime.View;

namespace Game.Runtime.Behavior.Session
{
    public class RenderChainNode<TModel, TView> : BehaviorNode
    where TModel : IVisualization<TView>
    {
        private readonly IEnumerable<TModel> _models;
        private readonly TView _view;

        public RenderChainNode(IEnumerable<TModel> models, TView view)
        {
            _models = models;
            _view = view;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            foreach (var model in _models)
            {
                model.Visualize(_view);
            }

            return BehaviorNodeStatus.Success;
        }
    }
}