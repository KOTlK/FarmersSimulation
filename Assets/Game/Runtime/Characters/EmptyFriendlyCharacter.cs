using BananaParty.BehaviorTree;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Characters
{
    public class EmptyFriendlyCharacter : IFriendlyCharacter
    {
        public void Visualize(IFriendlyCharacterView view)
        {
            view.DisplayAge(0);
            view.DisplayName(" ");
        }

        public Vector2 Position => Vector2.negativeInfinity;
        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view)
        {
        }

        public void Execute(long time)
        {
        }

        public Party Party => Party.Friend;
        public Profession Profession => Profession.Civilian;
        public Vector2 Direction { get; set; }
        public Vector3 Rotation { get; set; }
    }
}