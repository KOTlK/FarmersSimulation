using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;
using UnityEngine;

namespace Game.Runtime.Behavior.Characters.Professions.Farmer
{
    public class TargetPlant : ITargetPlant
    {
        private IPlant _origin;
        
        public bool HasTarget => _origin != null;
        public bool ReadyForGather => _origin.ReadyForGather;
        public Vector2 Position => _origin.Position;
        
        public void NewTarget(IPlant plant)
        {
            _origin = plant;
        }

        public void Reset()
        {
            _origin = null;
        }
        
        public void Gather(IResourcesStorage storage) => _origin.Gather(storage);
    }
}