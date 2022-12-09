using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Market;
using Game.Runtime.Resources;
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
        
        public void Select(ICharacter friendlyCharacter)
        {
            _character = friendlyCharacter;
        }

        public void Reset()
        {
            _character = null;
        }

        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view) => _character.Visualize(view);

        public void Execute(long time) => _character.Execute(time);
        public Vector2 Direction
        {
            get => _character.Direction;
            set => _character.Direction = value;
        }

        public Profession Profession => Profession.Civilian;
        public bool InventoryFull => _character.InventoryFull;
        public bool HasResourceCollected => _character.HasResourceCollected;
        public void Harvest(ICollectable collectable) => _character.Harvest(collectable);

        public void EmptyPockets(IResourceStorage targetStorage) => _character.EmptyPockets(targetStorage);

        public int CalculateSalary(IMarket market) => _character.CalculateSalary(market);

        public void PaySalary(int salary) => _character.PaySalary(salary);
    }
}