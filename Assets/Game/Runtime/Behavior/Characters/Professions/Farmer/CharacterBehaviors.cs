using System;
using System.Collections.Generic;
using Game.Runtime.Characters;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class CharacterBehaviors : ICharacterBehaviors
    {
        private readonly Dictionary<ICharacter, IBehavior> _characterBehaviors = new();

        public CharacterBehaviors(IReadOnlyList<ICharacter> characters, IReadOnlyList<IBehavior> behaviors)
        {
            if (characters.Count != behaviors.Count)
                throw new ArgumentException();
            
            for (var i = 0; i < characters.Count; i++)
            {
                _characterBehaviors.Add(characters[i], behaviors[i]);
            }
        }

        public IBehavior GetBehavior(ICharacter character) => _characterBehaviors[character];
    }
}