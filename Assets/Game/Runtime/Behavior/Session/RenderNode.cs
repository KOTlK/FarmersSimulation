using BananaParty.BehaviorTree;
using Game.Runtime.View;

namespace Game.Runtime.Behavior.Session
{
    public class RenderNode<TModel, TView> : BehaviorNode
    where TModel : IVisualization<TView>
    {
        private readonly TModel _model;
        private readonly TView _view;

        public RenderNode(TModel model, TView view)
        {
            _model = model;
            _view = view;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _model.Visualize(_view);
            return BehaviorNodeStatus.Success;
        }
    }
}