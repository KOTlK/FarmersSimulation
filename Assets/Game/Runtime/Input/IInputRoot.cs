using Game.Runtime.Input.Click;
using Game.Runtime.Input.Player;

namespace Game.Runtime.Input
{
    public interface IInputRoot
    {
        IMouse Mouse { get; }
        IPlayerInput PlayerInput { get; }
    }
}