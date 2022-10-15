using System.Collections.Generic;
using System.Linq;
using Game.Runtime.Inventory;
using UnityEngine;

namespace Game.Runtime.View.Storage
{
    public class StorageView : MonoBehaviour, IStorageView
    {
        [SerializeField] private ItemsFactory _itemsFactory = null;
        [SerializeField] private Transform _content = null;

        private readonly Dictionary<IItem, ItemView> _spawned = new();
        
        public void DisplayStorage(IEnumerable<(IItem, int)> items)
        {
            foreach (var (item, count) in items)
            {
                if (_spawned.ContainsKey(item))
                {
                    _spawned[item].SetCount(count);
                    return;
                }
                
                var spawnedItem = _itemsFactory.Create(item);
                spawnedItem.transform.SetParent(_content);
                spawnedItem.SetCount(count);
                _spawned.Add(item, spawnedItem);
            }

        }

        private void Clear()
        {
            foreach (var item in _spawned)
            {
                item.Value.Destroy();
            }

            _spawned.Clear();
        }
    }
}