using System;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;
using Game.Runtime.Session;
using Game.Runtime.View;
using UnityEngine;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public sealed class Wheat : ITile, IPlant, IGameLoop
    {
        public event Action<IPlant> Recovered = delegate {  };

        private int _ticksElapsed = 0;
        
        private const int TickWait = 20;

        public Wheat(Vector2Int position)
        {
            Position = position;
        }
        
        public bool Walkable { get; } = true;
        public Vector2Int Position { get; }
        public bool ReadyForGather { get; private set; } = false;

        public void Execute(long time)
        {
            if (ReadyForGather) return;
            
            _ticksElapsed++;
            if (_ticksElapsed < TickWait) return;
            ReadyForGather = true;
            Recovered.Invoke(this);
        }
        
        public void PickUp(IResourceStorage storage)
        {
            storage.Put(Resource.Wheat);
            _ticksElapsed = 0;
        }

        Vector2 ISceneObject.Position { get; }

        public void Visualize(ITileMapRenderer view)
        {
            view.SwitchTileInPosition(
                Position,
                ReadyForGather switch
                {
                    true => TileType.WheatGrown,
                    false => TileType.WheatUndergrown
                }
            );
        }
    }
}