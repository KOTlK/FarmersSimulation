using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.View;
using Game.Runtime.View.Characters;

namespace Game.Runtime.Characters
{
    public interface IFriendlyCharacter : ICharacter, IVisualization<IFriendlyCharacterView>, IBehavior
    {
        Profession Profession { get; }
    }
}