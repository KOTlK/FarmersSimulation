using Game.Runtime.Behavior;
using Game.Runtime.Behavior.Characters.Professions;

namespace Game.Runtime.Rendering
{
    public class DebugTreeRenderer : IRenderer
    {
        private readonly IBehavior _behavior;
        private readonly TreeVisualization _tree;

        public DebugTreeRenderer(IBehavior behavior, TreeVisualization tree)
        {
            _behavior = behavior;
            _tree = tree;
        }

        public void Render()
        {
            _behavior.Visualize(_tree);
            _tree.Visualize();
        }
    }
}