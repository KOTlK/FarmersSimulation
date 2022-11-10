using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Input.Characters
{
    public class CharacterSelector : ICharacterSelector
    {
        private ICharacter _character = new EmptyCharacter();

        public bool Exist => _character != null;

        public void Visualize(ICharacterView view) => _character.Visualize(view);

        public Vector2 Position => _character.Position;
        
        public void Select(ICharacter character)
        {
            _character = character;
        }

        public void Reset()
        {
            _character = null;
        }

        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view) => _character.Visualize(view);

        public void Execute(long time) => _character.Execute(time);
        public Party Party => _character.Party;
        public Profession Profession => _character.Profession;
        public Vector2 Direction
        {
            get => _character.Direction;
            set => _character.Direction = value;
        }
    }
}