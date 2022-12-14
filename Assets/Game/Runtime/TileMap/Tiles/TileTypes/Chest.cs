using System.Collections.Generic;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Market;
using Game.Runtime.Math.Vectors;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;
using Game.Runtime.View.Storage;

namespace Game.Runtime.TileMap.Tiles.TileTypes
{
    public sealed class Chest : ITile, IResourceStorage
    {
        private readonly IResourceStorage _origin;

        public Chest(Vector2Int position, IResourceStorage origin)
        {
            _origin = origin;
            Position = position;
        }

        public Vector2Int Position { get; }
        public bool Walkable { get; } = false;
        public int Count() => _origin.Count();

        public int Count(Resource resource) => _origin.Count(resource);

        public int Count(IEnumerable<Resource> resources) => _origin.Count(resources);

        public bool EnoughSpace(int amount) => _origin.EnoughSpace(amount);

        public int CalculateCost(IMarket market) => _origin.CalculateCost(market);

        public void Visualize(IResourceStorageView view) => _origin.Visualize(view);

        public void Put(Resource resource, int amount = 1) => _origin.Put(resource, amount);

        public IResourcePack Take(Resource resource, int amount = 1) => _origin.Take(resource, amount);

        public IResourcePack Take(IEnumerable<(Resource, int)> resources) => _origin.Take(resources);

        public IResourcePack Take(IEnumerable<Resource> resources) => _origin.Take(resources);

        public IResourcePack Take() => _origin.Take();
        public void Visualize(ITileMapRenderer view)
        {
            view.SwitchTileInPosition(Position, TileType.Chest);
        }
    }
}