using System;
using Game.Runtime.Environment;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;
using Game.Runtime.Session;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public abstract class CollectableResource : Decorator, IRecoverable<CollectableResource>, ICollectable, IGameLoop
    {
        public event Action<CollectableResource> Recovered = delegate { };

        private int _ticksElapsed = 0;

        protected CollectableResource(ITile origin) : base(origin) { }
        
        protected abstract Resource Resource { get; }
        protected abstract int Cooldown { get; }

        public bool ReadyForGather { get; private set; } = false;
        public void PickUp(IResourceStorage storage)
        {
            if (ReadyForGather)
            {
                storage.Put(Resource);
                _ticksElapsed = 0;
                ReadyForGather = false;
            }
        }

        public void Execute(long time)
        {
            if (ReadyForGather) return;
            
            _ticksElapsed++;
            if (_ticksElapsed < Cooldown) return;
            ReadyForGather = true;
            Recovered.Invoke(this);
        }
    }
}