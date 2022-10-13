using System.Collections.Generic;
using Game.Runtime.Inventory;
using UnityEngine;

namespace Game.Runtime.View.Storage
{
    public class StorageView : MonoBehaviour, IStorageView
    {
        [SerializeField] private GameObject _dummyPrefab = null;

        private readonly Dictionary<IItem, GameObject> _spawned = new();
        
        public void DisplayStorage(IEnumerable<IItem> items)
        {
            Clear();
            foreach (var item in items)
            {
                var spawned = Instantiate(_dummyPrefab, transform);
                _spawned.Add(item, spawned);
            }
        }

        private void Clear()
        {
            foreach (var item in _spawned)
            {
                Destroy(item.Value);
            }

            _spawned.Clear();
        }
    }
}