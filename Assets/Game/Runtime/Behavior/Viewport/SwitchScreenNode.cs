using BananaParty.BehaviorTree;
using Game.Runtime.View.Screens;

namespace Game.Runtime.Behavior.Viewport
{
    public class SwitchScreenNode : BehaviorNode
    {
        private readonly Screen _screen;
        private readonly IViewport _viewport;

        public SwitchScreenNode(Screen screen, IViewport viewport)
        {
            _screen = screen;
            _viewport = viewport;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _viewport.SwitchScreen(_screen);
            return BehaviorNodeStatus.Success;
        }
    }
}