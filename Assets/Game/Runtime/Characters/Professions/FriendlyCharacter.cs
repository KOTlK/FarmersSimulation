using BananaParty.BehaviorTree;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Random;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Characters.Professions
{
    public abstract class FriendlyCharacter : Character, IFriendlyCharacter
    {
        [SerializeField] private string _name = "Bob";
        [SerializeField] private float _age = 18f;

        private IBehavior _behavior;
        
        public abstract Profession Profession { get; }
        
        public void Initialize(IRandomGenerator<string> randomName, IRandomGenerator<float> randomAge, IBehavior behavior)
        {
            _name = randomName.Next();
            _age = randomAge.Next();
            _behavior = behavior;
        }

        public void Visualize(IFriendlyCharacterView view)
        {
            view.DisplayBehavior(_behavior);
            view.DisplayAge(_age);
            view.DisplayName(_name);
            view.DisplayProfession(Profession);
        }
        
        public void Execute(long time)
        {
            _behavior.Execute(time);
        }

        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view)
        {
            _behavior.Visualize(view);
        }
    }
}