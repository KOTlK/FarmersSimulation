using System.Collections.Generic;
using Game.Runtime.Characters;
using Game.Runtime.Math.Vectors;

namespace Game.Runtime.Input.Characters
{
    public class Characters : ICharacterInputs
    {
        private readonly List<ICharacter> _characters;

        public Characters(IEnumerable<ICharacter> characters)
        {
            _characters = new List<ICharacter>(characters);
        }

        public bool HasCharacterInPosition(Vector2Int position)
        {
            return _characters.FindAll(character => character.Position == position).Count > 0;
        }

        public ICharacter Get(Vector2Int position)
        {
            return _characters.FindAll(character => character.Position == position)[0];
        }
    }
}