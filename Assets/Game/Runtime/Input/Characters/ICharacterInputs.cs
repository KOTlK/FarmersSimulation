using Game.Runtime.Characters;
using Game.Runtime.Math.Vectors;

namespace Game.Runtime.Input.Characters
{
    public interface ICharacterInputs
    {
        bool HasCharacterInPosition(Vector2Int position);
        ICharacter Get(Vector2Int position);
    }
}