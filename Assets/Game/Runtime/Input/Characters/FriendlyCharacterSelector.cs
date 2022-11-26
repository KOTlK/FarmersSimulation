using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Input.Characters
{
    public class FriendlyCharacterSelector : IFriendlyCharacterSelector
    {
        private IFriendlyCharacter _friendlyCharacter = new EmptyFriendlyCharacter();

        public bool Exist => _friendlyCharacter != null;

        public void Visualize(IFriendlyCharacterView view) => _friendlyCharacter.Visualize(view);

        public Vector2 Position => _friendlyCharacter.Position;
        
        public void Select(IFriendlyCharacter friendlyCharacter)
        {
            _friendlyCharacter = friendlyCharacter;
        }

        public void Reset()
        {
            _friendlyCharacter = null;
        }

        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view) => _friendlyCharacter.Visualize(view);

        public void Execute(long time) => _friendlyCharacter.Execute(time);
        public Profession Profession => _friendlyCharacter.Profession;
        public Vector2 Direction
        {
            get => _friendlyCharacter.Direction;
            set => _friendlyCharacter.Direction = value;
        }
    }
}