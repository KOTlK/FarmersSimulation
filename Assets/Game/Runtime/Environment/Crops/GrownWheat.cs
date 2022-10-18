using System;
using System.Collections.Generic;
using Game.Runtime.Environment.Crops.MonoBehaviours;

namespace Game.Runtime.Environment.Crops
{
    public class GrownWheat : IGrownPlants
    {
        private readonly Stack<Plant> _readyForGather = new();
        private readonly List<Plant> _notReady;

        public GrownWheat(IEnumerable<Plant> plants)
        {
            _notReady = new List<Plant>(plants);
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