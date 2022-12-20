using System.Collections.Generic;
using System.Linq;
using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Input.Characters;
using Game.Runtime.Input.Click;

namespace Game.Runtime.Behavior.Session
{
    public class IsCharacterClickedNode : BehaviorNode
    {
        private readonly ICharacterSelector _characterSelector;
        private readonly IMouse _mouse;
        private readonly IEnumerable<ICharacter> _spawnedCharacters;

        public IsCharacterClickedNode(IMouse mouse, IEnumerable<ICharacter> spawnedCharacters, ICharacterSelector characterSelector)
        {
            _mouse = mouse;
            _characterSelector = characterSelector;
            _spawnedCharacters = spawnedCharacters;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_mouse.Clicked == false) return BehaviorNodeStatus.Failure;
            
            var character = _spawnedCharacters.FirstOrDefault(character => character.Position == _mouse.Position);

            if (character == null)
                return BehaviorNodeStatus.Failure;

            _characterSelector.Select(character);
            return BehaviorNodeStatus.Success;

        }
    }
}