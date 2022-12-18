using System;
using System.Collections.Generic;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.View.Field;
using UnityEngine;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.Rendering.Tiles
{
    public class TileMapRenderer : MonoBehaviour, ITileMapRenderer
    {
        [SerializeField] private TilesDictionary _dictionary;

        private readonly Dictionary<Vector2Int, ITileView> _tiles = new();
        private readonly Dictionary<Vector2Int, ITileView> _decorators = new();

        private void Awake()
        {
            _dictionary.Init();
        }

        public void SwitchTileInPosition(Vector2Int position, TileType type)
        {
            if (_tiles.ContainsKey(position) == false)
            {
                var view = Instantiate(_dictionary.Get(type), transform);
                view.DisplayTile(position);
                _tiles.Add(position, view);
            }
            else
            {
                if (_tiles[position].TileType == type)
                    return;
                
                _tiles[position].Destroy();
                _tiles[position] = Instantiate(_dictionary.Get(type), transform);
                _tiles[position].DisplayTile(position);
            }
        }

        public void DisplayDecorator(Vector2Int position, TileType type)
        {
            if (_decorators.ContainsKey(position) == false)
            {
                var view = Instantiate(_dictionary.Get(type), transform);
                view.DisplayTile(position);
                _decorators[position] = view;
            }
            else
            {
                if (type == TileType.Empty)
                {
                    _decorators[position].Destroy();
                    _decorators.Remove(position);
                    return;
                }
                
                if (_decorators[position].TileType == type)
                    return;
                
                _decorators[position].Destroy();
                _decorators[position] = Instantiate(_dictionary.Get(type), transform);
                _decorators[position].DisplayTile(position);
            }
        }
    }
}