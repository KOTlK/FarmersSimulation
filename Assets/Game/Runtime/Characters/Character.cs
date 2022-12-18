using BananaParty.BehaviorTree;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Market;
using Game.Runtime.Math.Vectors;
using Game.Runtime.Random;
using Game.Runtime.Rendering.Characters;
using Game.Runtime.Resources;
using Game.Runtime.View.Characters;

namespace Game.Runtime.Characters
{
    public class Character : ICharacter
    {
        private readonly string _name;
        private readonly float _age;
        
        private readonly IResourceStorage _inventory = new ResourceStorage(15);
        private readonly IResourceStorage _gatheredResources = new ResourceStorage(1000);
        private readonly IWallet _wallet = new Wallet();
        
        public Character (IRandomGenerator<string> randomName, IRandomGenerator<float> randomAge, Vector2Int startPosition)
        {
            _name = randomName.Next();
            _age = randomAge.Next();
            Position = startPosition;
        }
        
        public Vector2Int Position { get; private set; }
        public Profession Profession { get; private set; } = Profession.Farmer;
        public bool InventoryFull => _inventory.EnoughSpace(1) == false;
        public bool HasResourceCollected => _inventory.Count() > 0;

        public void Visualize(ICharacterView view)
        {
            view.DisplayAge(_age);
            view.DisplayName(_name);
            view.DisplayProfession(Profession);
            _wallet.Visualize(view);
        }
        
        public void Harvest(ICollectable collectable)
        {
            collectable.PickUp(_inventory);
        }

        public void EmptyPockets(IResourceStorage targetStorage)
        {
            if (HasResourceCollected)
            {
                var resources = _inventory.Take();
                resources.Transfer(targetStorage);
                resources.Transfer(_gatheredResources);
            }
        }

        public int CalculateSalary(IMarket market)
        {
            var salary = _gatheredResources.CalculateCost(market);
            _gatheredResources.Take();
            return salary;
        }

        public void PaySalary(int salary)
        {
            _wallet.Put(salary);
        }

        public void Visualize(ICharacterRenderer view)
        {
            view.Display(this, Profession);
        }

        public void Move(Vector2Int direction)
        {
            Position = new Sum(direction, Position);
        }
    }
}