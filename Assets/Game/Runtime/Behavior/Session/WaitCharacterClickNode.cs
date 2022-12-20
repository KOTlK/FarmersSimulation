using System.Collections.Generic;
using System.Linq;
using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Input;
using Game.Runtime.Input.Characters;
using Game.Runtime.Input.Click;

namespace Game.Runtime.Behavior.Session
{
    public class WaitCharacterClickNode : BehaviorNode
    {
        private readonly ICharacterSelector _characterSelectorSelector;
        private readonly IMouse _mouse;
        private readonly IEnumerable<ICharacter> _characters;

        public WaitCharacterClickNode(ICharacterSelector characterSelectorSelector, IMouse mouse, IEnumerable<ICharacter> characters)
        {
            _characterSelectorSelector = characterSelectorSelector;
            _mouse = mouse;
            _characters = characters;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_mouse.Clicked == false)
                return BehaviorNodeStatus.Running;

            var character = _characters.FirstOrDefault(character => character.Position == _mouse.Position);

            if (character == null)
                return BehaviorNodeStatus.Running;

            _characterSelectorSelector.Select(character);
            return BehaviorNodeStatus.Success;
        }
    }
}