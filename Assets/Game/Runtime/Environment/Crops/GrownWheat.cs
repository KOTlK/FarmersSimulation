using System;
using System.Collections.Generic;
using Game.Runtime.Environment.Crops.MonoBehaviours;

namespace Game.Runtime.Environment.Crops
{
    public class GrownWheat : IGrownPlants
    {
        private readonly Stack<Plant<WheatPlant>> _readyForGather = new();
        private readonly List<Plant<WheatPlant>> _notReady;

        public GrownWheat(IEnumerable<Plant<WheatPlant>> plants)
        {
            _notReady = new List<Plant<WheatPlant>>(plants);
            foreach (var plant in plants)
            {
                plant.Grown += _readyForGather.Push;
            }
        }

        public IPlant GetPlant()
        {
            if (HasGrownPlants() == false)
                throw new Exception("No plants ready");

            return _readyForGather.Pop();
        }

        public bool HasGrownPlants() => _readyForGather.Count > 0;
    }
}