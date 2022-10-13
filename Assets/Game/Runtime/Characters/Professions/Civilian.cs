using UnityEngine;

namespace Game.Runtime.Characters.Professions
{
    public class Civilian : Character
    {
        [SerializeField] private Party _party;

        public override Party Party => _party;
        public override Profession Profession => Profession.Civilian;
    }
}