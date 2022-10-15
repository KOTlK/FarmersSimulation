using System;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Inventory;
using UnityEngine;

namespace Game.Runtime.View.Storage
{
    public class ItemsFactory : MonoBehaviour
    {
        [SerializeField] private ItemView _wheatPrefab;
        
        public ItemView Create(IItem item)
        {
            return item switch
            {
                WheatPlant => Instantiate(_wheatPrefab),
                _ => throw new ArgumentOutOfRangeException(nameof(item), item, null)
            };
        }
    }
}