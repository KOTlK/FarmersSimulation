using Game.Runtime.View;
using Game.Runtime.View.Characters;

namespace Game.Runtime.Characters
{
    public interface ICharacter : IMovement, IVisualization<INameView, IAgeView, IProfessionView>, ISceneObject
    {
    }
}