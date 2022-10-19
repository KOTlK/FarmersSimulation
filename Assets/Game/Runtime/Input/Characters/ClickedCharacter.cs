using BananaParty.BehaviorTree;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Characters;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Input.Characters
{
    public class ClickedCharacter : IClickedCharacter
    {
        private ICharacter _character = new EmptyCharacter();

        private readonly ICharacterBehaviors _behaviors;

        public ClickedCharacter(ICharacterBehaviors behaviors)
        {
            _behaviors = behaviors;
        }

        public bool Exist => _character != null;
        public void Move(Vector2 direction) => _character.Move(direction);

        public void Visualize(ICharacterView view) => _character.Visualize(view);

        public Vector2 Position => _character.Position;
        
        public void Add(ICharacter character)
        {
            _character = character;
        }

        public void Reset()
        {
            _character = null;
        }

        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view) => _behaviors.GetBehavior(this).Visualize(view);

        public void Execute(long time) => _behaviors.GetBehavior(this).Execute(time);
    }
}