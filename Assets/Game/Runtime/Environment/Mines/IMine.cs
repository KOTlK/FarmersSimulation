using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;

namespace Game.Runtime.Environment.Mines
{
    public interface IMine : ICollectable, IRecoverable<IMine>
    {
    }
}