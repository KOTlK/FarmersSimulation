using System.Collections.Generic;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.View.Field;
using UnityEngine;

namespace Game.Runtime.Rendering.Tiles
{
    [CreateAssetMenu(menuName = "ScriptableHell/TilesDict")]
    public class TilesDictionary : ScriptableObject
    {
        [SerializeField] private TileByType[] _tiles;

        private readonly Dictionary<TileType, Tile> _dictionary = new();

        public void Init()
        {
            foreach (var tile in _tiles)
            {
                _dictionary.Add(tile.Type, tile.Prefab);
            }
        }

        public Tile Get(TileType type) => _dictionary[type];
    }
}