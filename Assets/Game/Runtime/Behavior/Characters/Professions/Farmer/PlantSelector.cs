using System;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;
using UnityEngine;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class PlantSelector : IPlantSelector
    {
        private IPlant _origin;
        
        public bool Exist => _origin != null;
        public bool ReadyForGather => _origin.ReadyForGather;
        public Vector2 Position => _origin.Position;
        
        public void Select(IPlant plant)
        {
            _origin = plant;
            _origin.Recovered += Recovered.Invoke;
        }

        public void Reset()
        {
            if (_origin != null)
            {
                _origin.Recovered -= Recovered.Invoke;
                _origin = null;
            }
        }
        
        public void PickUp(IResourcesStorage storage) => _origin.PickUp(storage);
        public event Action<IPlant> Recovered = delegate { };
    }
}