using System.Collections.Generic;
using Game.Runtime.Characters;

namespace Game.Runtime.Input.Characters
{
    public class CharacterInputs : IClickInputs<ICharacter>
    {
        private readonly Queue<ICharacter> _clickedCharacters = new();

        public CharacterInputs(IClickInput<ICharacter>[] inputs)
        {
            foreach (var input in inputs)
            {
                input.Clicked += OnClick;
            }
        }

        public bool HasUnreadInput => _clickedCharacters.Count > 0;
        
        public ICharacter GetInput()
        {
            var character = _clickedCharacters.Dequeue();
            Clear();
            return character;
        }

        public void Clear()
        {
            _clickedCharacters.Clear();
        }

        private void OnClick(ICharacter character)
        {
            _clickedCharacters.Enqueue(character);
        }
    }
}