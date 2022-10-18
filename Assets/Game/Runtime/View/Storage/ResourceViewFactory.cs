using System;
using Game.Runtime.Resources;
using UnityEngine;

namespace Game.Runtime.View.Storage
{
    public class ResourceViewFactory : MonoBehaviour
    {
        [SerializeField] private ResourceView _wheatPrefab;
        
        public ResourceView Create(Resource item)
        {
            return item switch
            {
                Resource.Wheat => Instantiate(_wheatPrefab),
                _ => throw new ArgumentOutOfRangeException(nameof(item), item, null)
            };
        }
    }
}