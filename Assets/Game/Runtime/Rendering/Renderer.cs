using Game.Runtime.View;

namespace Game.Runtime.Rendering
{
    public class Renderer<TModel, TView> : IRenderer
    where TModel : IVisualization<TView>
    {
        private readonly TModel _model;
        private readonly TView _view;

        public Renderer(TModel model, TView view)
        {
            _model = model;
            _view = view;
        }

        public void Render()
        {
            _model.Visualize(_view);
        }
    }
}