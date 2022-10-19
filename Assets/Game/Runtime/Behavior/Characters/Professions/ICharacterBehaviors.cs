using Game.Runtime.Characters;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public interface ICharacterBehaviors
    {
        IBehavior GetBehavior(ICharacter character);
    }
}