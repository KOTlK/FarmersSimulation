using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;

namespace Game.Runtime.Characters.Professions.Miner
{
    public class Miner : Character, IMiner
    {
        private readonly IResourcesStorage _inventory = new ResourceStorage(10);
        
        public override Profession Profession => Profession.Miner;
        public bool InventoryFull => _inventory.EnoughSpace(1) == false;
        public bool HasResourceCollected => _inventory.Count(new[]
        {
            Resource.Copper,
            Resource.Iron,
            Resource.Gold,
            Resource.Silver
        }) > 0;
        public void Harvest(ICollectable collectable)
        {
            collectable.PickUp(_inventory);
        }

        public void EmptyPockets(IResourcesStorage targetStorage)
        {
            if (HasResourceCollected)
            {
                var pack = _inventory.Take(new []
                {
                    (Resource.Copper, _inventory.Count(Resource.Copper))
                });
                pack.Transfer(targetStorage);
            }
        }
    }
}