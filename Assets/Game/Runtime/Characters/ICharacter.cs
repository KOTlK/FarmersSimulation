using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.View;
using Game.Runtime.View.Characters;

namespace Game.Runtime.Characters
{
    public interface ICharacter : IMovement, IVisualization<ICharacterView>, ISceneObject
    {
    }
}