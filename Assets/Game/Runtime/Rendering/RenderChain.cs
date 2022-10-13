namespace Game.Runtime.Rendering
{
    public class RenderChain : IRenderer
    {
        private readonly IRenderer[] _renderers;

        public RenderChain(IRenderer[] renderers)
        {
            _renderers = renderers;
        }

        public void Render()
        {
            foreach (var renderer in _renderers)
            {
                renderer.Render();
            }
        }
    }
}