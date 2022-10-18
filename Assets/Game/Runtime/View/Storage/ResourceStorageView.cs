using System.Collections.Generic;
using Game.Runtime.Resources;
using UnityEngine;

namespace Game.Runtime.View.Storage
{
    public class ResourceStorageView : MonoBehaviour, IResourceStorageView
    {
        [SerializeField] private ResourceViewFactory _itemsFactory = null;
        [SerializeField] private Transform _content = null;

        private readonly Dictionary<Resource, ResourceView> _spawned = new();
        
        public void DisplayStorage(Dictionary<Resource, int> items)
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
    }
}