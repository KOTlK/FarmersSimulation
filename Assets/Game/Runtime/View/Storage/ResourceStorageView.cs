using System.Collections.Generic;
using Game.Runtime.Input.View;
using Game.Runtime.Input.View.Storage;
using Game.Runtime.Resources;
using UnityEngine;

namespace Game.Runtime.View.Storage
{
    public class ResourceStorageView : MonoBehaviour, IResourceStorageView, IStorageElement
    {
        [SerializeField] private ResourceViewFactory _itemsFactory = null;
        [SerializeField] private Transform _content = null;
        [SerializeField] private Button _button = null;

        private readonly Dictionary<Resource, ResourceView> _spawned = new();
        
        public void DisplayStorage(Dictionary<Resource, int> items)
        {
            foreach (var (item, count) in items)
            {
                if (_spawned.ContainsKey(item))
                {
                    _spawned[item].SetCount(count);
                    continue;
                }
                
                var spawnedItem = _itemsFactory.Create(item);
                spawnedItem.transform.SetParent(_content);
                spawnedItem.SetCount(count);
                _spawned.Add(item, spawnedItem);
            }

        }

        public IButton CloseButton => _button;

        public bool IsActive
        {
            get => gameObject.activeSelf;
            set
            {
                if (gameObject.activeSelf != value)
                    gameObject.SetActive(value);
            }
        }
    }
}