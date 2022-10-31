using System;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Characters.Professions.Farmer
{
    public class Farmer : Character, IFarmer
    {
        private readonly IResourcesStorage _inventory = new ResourceStorage(15);

        public override Profession Profession => Profession.Farmer;
        public bool HasResourceCollected => _inventory.Count(Resource.Wheat) > 0;
        public bool InventoryFull => _inventory.IsFull;

        public void Visualize(IResourceStorageView view)
        {
            _inventory.Visualize(view);
        }

        public void Harvest(ICollectable collectable)
        {
            collectable.PickUp(_inventory);
        }

        public void EmptyPockets(IResourcesStorage targetStorage)
        {
            if (_inventory.Count(Resource.Wheat) < 0)
                throw new Exception("Storage has no available item");

            var count = _inventory.Count(Resource.Wheat);

            if (targetStorage.EnoughSpace(count) == false)
                throw new Exception($"Not enough space in {nameof(targetStorage)}");
            
            _inventory.Take(Resource.Wheat, true);
            targetStorage.Put(Resource.Wheat, count);
        }
    }
}