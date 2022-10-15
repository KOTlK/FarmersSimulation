using Game.Runtime.Characters.Professions.Farmer;
using Game.Runtime.Environment.Crops.MonoBehaviours;
using Game.Runtime.Inventory;
using Game.Runtime.View.Storage;
using UnityEngine;

namespace Game.Runtime.Debugging
{
    public class DebugFarmer : MonoBehaviour
    {
        [SerializeField] private Farmer _farmer;
        [SerializeField] private WheatPlant _plant;
        [SerializeField] private StorageView _storageView;
        [SerializeField] private StorageView _worldStorageView;
        [SerializeField] private WorldStorage _worldStorage;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                _farmer.GatherPlant(_plant);
                _farmer.Visualize(_storageView);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftShift))
            {
                _farmer.EmptyPockets(_worldStorage);
                _farmer.Visualize(_storageView);
                _worldStorage.Visualize(_worldStorageView);
            }
        }
    }
}