using System;
using System.Collections.Generic;
using System.Linq;
using Game.Runtime.Resources;
using UnityEngine;

namespace Game.Game.Runtime.Factories
{
    [Serializable]
    public class Blueprint : IBlueprint
    {
        [SerializeField] private ResourceStack[] _income;
        [SerializeField] private ResourceStack[] _outcome;

        public bool CanBeCrafted(IResourcesStorage storage)
        {
            return _income.All(income => storage.Count(income.Resource) >= income.Amount);
        }

        public IResourcePack Craft(IResourcesStorage incomeStorage)
        {
            if (CanBeCrafted(incomeStorage) == false)
                throw new ArgumentException(nameof(incomeStorage));

            foreach (var income in _income)
            {
                incomeStorage.Take(income.Resource, false, income.Amount);
            }

            var pack = _outcome.Select(outcome => (outcome.Resource, outcome.Amount)).ToList();

            return new ResourcePack(pack);
        }

        [Serializable]
        public class ResourceStack
        {
            [field: SerializeField] public Resource Resource { get; private set; }
            [field: SerializeField] public int Amount { get; private set; }
        }
    }
}