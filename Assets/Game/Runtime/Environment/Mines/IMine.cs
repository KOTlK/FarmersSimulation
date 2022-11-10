using Game.Runtime.Environment.Crops;

namespace Game.Runtime.Environment.Mines
{
    public interface IMine : ICollectable, IRecoverable<IMine>
    {
    }
}