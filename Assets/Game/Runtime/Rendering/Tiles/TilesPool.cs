using System.Collections.Generic;
using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.View.Field;
using UnityEngine;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.Rendering.Tiles
{
    public class TilesPool
    {
        private readonly Transform _parent;
        private readonly TilesDictionary _prefabs;
        private readonly Dictionary<TileType, Stack<ITileView>> _spawned = new();

        private readonly Vector2Int _despawnPosition = new Vector2Int(-1000000, -1000000);

        public TilesPool(TilesDictionary prefabs, Transform parent)
        {
            _parent = parent;
            _prefabs = prefabs;
            _prefabs.Init();
        }


        public ITileView Get(TileType type)
        {
            if (_spawned.ContainsKey(type))
            {
                if (_spawned[type].Count > 0)
                {
                    var tile = _spawned[type].Pop();
                    return tile;
                }

                var spawnedTile = Object.Instantiate(_prefabs.Get(type), _parent);
                return spawnedTile;
            }

            var view = Object.Instantiate(_prefabs.Get(type), _parent);
            _spawned.Add(type, new Stack<ITileView>());
            return view;
        }

        public void Release(ITileView tile)
        {
            if (_spawned.ContainsKey(tile.TileType))
            {
                _spawned[tile.TileType].Push(tile);
            }
            else
            {
                _spawned.Add(tile.TileType, new Stack<ITileView>(new []
                {
                    tile
                }));
            }
            
            tile.DisplayTile(_despawnPosition);
        }
    }
}