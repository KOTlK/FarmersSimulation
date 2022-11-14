using Game.Runtime.Environment.Crops;
using Game.Runtime.View;

namespace Game.Runtime.Environment.Mines
{
    public interface IMine : ICollectable, IRecoverable<IMine>, ISceneObject
    {
    }
}