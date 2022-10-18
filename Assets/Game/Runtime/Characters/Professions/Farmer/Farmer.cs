using System;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;
using Game.Runtime.View.Storage;
using UnityEngine;

namespace Game.Runtime.Characters.Professions.Farmer
{
    public class Farmer : Character, IFarmer
    {
        [SerializeField] private Party _party;

        private readonly IResourcesStorage _inventory = new ResourceStorage(15);

        public override Party Party => _party;
        public override Profession Profession => Profession.Farmer;
        public bool HasCollectedPlants => _inventory.HasResource(Resource.Wheat);
        public bool InventoryFull => _inventory.IsFull;
        
        public void Visualize(IResourceStorageView view)
        {
            _inventory.Visualize(view);
        }

        public void GatherPlant(ICollectable plant)
        {
            plant.Gather(_inventory);
        }

        public void EmptyPockets(IResourcesStorage targetStorage)
        {
            if (_inventory.HasResource(Resource.Wheat) == false)
                throw new Exception("Storage has no available item");

            var count = _inventory.Count(Resource.Wheat);

            if (targetStorage.EnoughSpace(count) == false)
                throw new Exception($"Not enough space in {nameof(targetStorage)}");
            
            _inventory.Remove(Resource.Wheat, count);
            targetStorage.Put(Resource.Wheat, count);
        }
    }
}