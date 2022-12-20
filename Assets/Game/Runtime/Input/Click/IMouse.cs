using Game.Runtime.Math.Vectors;

namespace Game.Runtime.Input.Click
{
    public interface IMouse
    {
        bool Clicked { get; }
        Vector2Int Position { get; }
    }
}