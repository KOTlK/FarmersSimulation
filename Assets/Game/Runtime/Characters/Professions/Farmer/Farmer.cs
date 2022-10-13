using System;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Inventory;
using Game.Runtime.View.Storage;
using UnityEngine;

namespace Game.Runtime.Characters.Professions.Farmer
{
    public class Farmer : Character, IFarmer
    {
        [SerializeField] private Party _party;

        private readonly IStorage _inventory = new Storage(15);

        public override Party Party => _party;
        public override Profession Profession => Profession.Farmer;
        public bool HasCollectedPlants => _inventory.HasItem<WheatPlant>();
        public bool InventoryFull => _inventory.IsFull;
        
        public void Visualize(IStorageView view)
        {
            _inventory.Visualize(view);
        }

        public void GatherPlant(ICollectable plant)
        {
            plant.Gather(_inventory);
        }

        public void EmptyPockets(IStorage targetStorage)
        {
            if (_inventory.HasItem<WheatPlant>() == false)
                throw new Exception("Storage has no available item");

            while (_inventory.HasItem<WheatPlant>())
            {
                targetStorage.Put<WheatPlant>(_inventory.Take<WheatPlant>());
            }
        }
    }
}