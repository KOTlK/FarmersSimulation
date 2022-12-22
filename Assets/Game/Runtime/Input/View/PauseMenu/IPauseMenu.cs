namespace Game.Runtime.Input.View.PauseMenu
{
    public interface IPauseMenu
    {
        IButton Continue { get; }
        IButton Exit { get; }
    }
}