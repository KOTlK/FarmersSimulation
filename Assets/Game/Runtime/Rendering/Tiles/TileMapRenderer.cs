using System;
using System.Collections.Generic;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Math.Vectors;
using Game.Runtime.View.Field;
using UnityEngine;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.Rendering.Tiles
{
    public class TileMapRenderer : MonoBehaviour, ITileMapRenderer
    {
        [SerializeField] private Tile _grass, _soil, _rock, _wheatUndergrown, _wheatGrown, _chest, _empty;
        [Space, Header("0 - leftBottom, 2 - rightBottom, 8 - rightUpper")]
        [SerializeField] private Tile[] _factoryParts;//0 - leftBottom, 2 - rightBottom, 8 - rightUpper

        private readonly Dictionary<Vector2Int, ITileView> _tiles = new();

        //Pizdec))000))
        public void SwitchTileInPosition(Vector2Int position, TileType type)
        {
            if (_tiles.ContainsKey(position))
            {
                if (_tiles[position].TileType == type)
                    return;
            }
            
            if (type == TileType.Factory)
            {
                var offsets = new Vector2Int[]
                {
                    new(0,0),
                    new(1,0),
                    new(2,0),
                    new(0,1),
                    new(1,1),
                    new(2,1),
                    new(0,2),
                    new(1,2),
                    new(2,2),
                };
                
                for(var i = 0; i < _factoryParts.Length; i++)
                {
                    var part = Instantiate(_factoryParts[i], transform);
                    var partPosition = new Sum(position, offsets[i]);
                    
                    if (_tiles.ContainsKey(partPosition))
                    {
                        _tiles[partPosition].Destroy();
                        _tiles.Remove(partPosition);
                    }
                    
                    _tiles.Add(partPosition, part);
                    part.DisplayTile(partPosition);
                }

                return;
            }
            
            if (_tiles.ContainsKey(position) == false)
            {
                var view = Instantiate(PrefabByType(type), transform);
                view.DisplayTile(position);
                _tiles.Add(position, view);
            }
            else
            {
                _tiles[position].Destroy();
                _tiles[position] = Instantiate(PrefabByType(type), transform);
                _tiles[position].DisplayTile(position);
            }
        }

        private Tile PrefabByType(TileType type)
        {
            return type switch
            {
                TileType.Grass => _grass,
                TileType.Soil => _soil,
                TileType.Rock => _rock,
                TileType.WheatUndergrown => _wheatUndergrown,
                TileType.WheatGrown => _wheatGrown,
                TileType.Chest => _chest,
                TileType.Empty => _empty,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}