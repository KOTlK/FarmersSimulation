using BananaParty.BehaviorTree;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Market;
using Game.Runtime.Random;
using Game.Runtime.Resources;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Characters
{
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private string _name = "Bob";
        [SerializeField] private float _age = 18f;
        [SerializeField] private Profession _profession;

        private IBehavior _behavior;
        
        private readonly IResourceStorage _inventory = new ResourceStorage(15);
        private readonly IResourceStorage _gatheredResources = new ResourceStorage(1000);
        private readonly IWallet _wallet = new Wallet();
        
        public void Initialize(IRandomGenerator<string> randomName, IRandomGenerator<float> randomAge, IBehavior behavior)
        {
            _name = randomName.Next();
            _age = randomAge.Next();
            _behavior = behavior;
        }

        public Profession Profession => _profession;

        protected void Update()
        {
            if (Direction != Vector2.zero)
                Move(Direction);
        }

        public Vector2 Direction { get; set; }
        public Vector2 Position => transform.position;

        private void Move(Vector2 direction)
        {
            var deltaMovement = direction.normalized * _speed * Time.deltaTime;
            transform.position += (Vector3)deltaMovement;
        }

        public void Visualize(ICharacterView view)
        {
            view.DisplayBehavior(_behavior);
            view.DisplayAge(_age);
            view.DisplayName(_name);
            view.DisplayProfession(Profession);
            _wallet.Visualize(view);
        }
        
        public void Execute(long time)
        {
            _behavior.Execute(time);
        }
        
        public bool InventoryFull => _inventory.EnoughSpace(1) == false;
        public bool HasResourceCollected => _inventory.Count() > 0;
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

        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view)
        {
            _behavior.Visualize(view);
        }
    }
}