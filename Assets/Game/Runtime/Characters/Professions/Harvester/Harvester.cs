using Game.Runtime.Market;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;
using UnityEngine;

namespace Game.Runtime.Characters.Professions.Harvester
{
    public class Harvester : FriendlyCharacter, IHarvester
    {
        [SerializeField] private Profession _profession;
        
        private readonly IResourcesStorage _inventory = new ResourceStorage(15);
        private readonly IResourcesStorage _gatheredResources = new ResourceStorage(1000);
        private readonly IWallet _wallet = new Wallet();
        
        public override Profession Profession => _profession;
        public bool InventoryFull => _inventory.EnoughSpace(1) == false;
        public bool HasResourceCollected => _inventory.Count() > 0;
        public void Harvest(ICollectable collectable)
        {
            collectable.PickUp(_inventory);
        }

        public void EmptyPockets(IResourcesStorage targetStorage)
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
    }
}