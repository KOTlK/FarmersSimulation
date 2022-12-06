using System;
using Game.Runtime.Resources;
using UnityEngine;

namespace Game.Runtime.View.Storage
{
    public class ResourceViewFactory : MonoBehaviour
    {
        [SerializeField] private ResourceView _wheatPrefab,
            _ironPrefab,
            _copperPrefab,
            _silverPrefab,
            _goldPrefab,
            _breadPrefab,
            _ironSwordPrefab,
            _copperSwordPrefab,
            _moneyPrefab;
        
        public ResourceView Create(Resource item)
        {
            return item switch
            {
                Resource.Wheat => Instantiate(_wheatPrefab),
                Resource.Copper => Instantiate(_copperPrefab),
                Resource.Iron => Instantiate(_ironPrefab),
                Resource.Silver => Instantiate(_silverPrefab),
                Resource.Gold => Instantiate(_goldPrefab),
                Resource.Bread => Instantiate(_breadPrefab),
                Resource.IronSword => Instantiate(_ironSwordPrefab),
                Resource.CopperSword => Instantiate(_copperSwordPrefab),
                Resource.Money => Instantiate(_moneyPrefab),
                _ => throw new ArgumentOutOfRangeException(nameof(item), item, null)
            };
        }
    }
}