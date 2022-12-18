using Game.Runtime.Characters;

namespace Game.Runtime.Rendering.Characters
{
    public interface ICharacterRenderer
    {
        void Display(ICharacter character, Profession type);
    }
}