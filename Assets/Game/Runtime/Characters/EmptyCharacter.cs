﻿using BananaParty.BehaviorTree;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Characters
{
    public class EmptyCharacter : ICharacter
    {
        public void Move(Vector2 direction)
        {
        }

        public void Visualize(ICharacterView view)
        {
            view.DisplayAge(0);
            view.DisplayName(" ");
            view.DisplayProfession(Profession.Civilian);
        }

        public Vector2 Position => Vector2.negativeInfinity;
        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view)
        {
        }

        public void Execute(long time)
        {
        }

        public Party Party => Party.Red;
        public Profession Profession => Profession.Civilian;
    }
}