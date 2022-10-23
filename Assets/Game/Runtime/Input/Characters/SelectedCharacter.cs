using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Input.Characters
{
    public class SelectedCharacter : ISelectedCharacter
    {
        private ICharacter _character = new EmptyCharacter();

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

        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view) => _character.Visualize(view);

        public void Execute(long time) => _character.Execute(time);
        public Party Party => _character.Party;
        public Profession Profession => _character.Profession;
    }
}