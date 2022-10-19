using Game.Runtime.Characters;

namespace Game.Runtime.Input.Characters
{
    public interface IClickedCharacter : ICharacter
    {
        bool Exist { get; }
        void Add(ICharacter character);
        void Reset();
    }
}