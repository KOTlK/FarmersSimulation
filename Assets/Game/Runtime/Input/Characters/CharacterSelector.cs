using BananaParty.BehaviorTree;
using Game.Runtime.Characters;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Market;
using Game.Runtime.Math.Vectors;
using Game.Runtime.Rendering.Characters;
using Game.Runtime.Resources;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.View.Characters;

namespace Game.Runtime.Input.Characters
{
    public class CharacterSelector : ICharacterSelector
    {
        private ICharacter _character;
        
        public bool Exist => _character != null;

        public void Visualize(ICharacterView view) => _character.Visualize(view);
        
        public void Select(ICharacter friendlyCharacter)
        {
            _character = friendlyCharacter;
        }

        public void Reset()
        {
            _character = null;
        }

        public Profession Profession => _character.Profession;
        public bool InventoryFull => _character.InventoryFull;
        public bool HasResourceCollected => _character.HasResourceCollected;
        public void Harvest(ICollectable collectable) => _character.Harvest(collectable);

        public void EmptyPockets(IResourceStorage targetStorage) => _character.EmptyPockets(targetStorage);

        public int CalculateSalary(IMarket market) => _character.CalculateSalary(market);

        public void PaySalary(int salary) => _character.PaySalary(salary);

        Vector2Int ITransform.Position => _character.Position;

        public void Move(Vector2Int direction) => _character.Move(direction);

        public void Visualize(ICharacterRenderer view) => _character.Visualize(view);
    }
}