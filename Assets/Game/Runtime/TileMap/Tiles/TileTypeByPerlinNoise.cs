using System;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Math.Vectors;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.TileMap.Tiles.TileTypes;
using UnityEngine;
using Random = System.Random;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.TileMap.Tiles
{
    public class TileTypeByPerlinNoise : ITileRule
    {
        private readonly Vector2Int _size;
        private readonly Vector2Int _noiseOffset;
        private readonly float _noiseScale;
        private readonly System.Random _random = new();

        public TileTypeByPerlinNoise(Vector2Int size, Vector2Int noiseOffset, float noiseScale)
        {
            _size = size;
            _noiseOffset = noiseOffset;
            _noiseScale = noiseScale;
        }
        
        public ITile Next(Vector2Int position)
        {
            var noise = Mathf.PerlinNoise((float)(position.X + _noiseOffset.X) * _noiseScale / _size.X, (float)(position.Y + _noiseOffset.Y) * _noiseScale / _size.Y);
            return PerlinNoiseToTile(noise, position);
        }


        private ITile PerlinNoiseToTile(float noise, Vector2Int position)
        {
            return noise switch
            {
                <= 0.3f => WheatOrSoil(position),
                <= 0.6f => new Grass(position),
                > 0.6f => new Rock(position),
                _ => throw new ArgumentOutOfRangeException(nameof(noise), noise, null)
            };
        }

        private ITile WheatOrSoil(Vector2Int position)
        {
            var randomValue = _random.Next(0, 100);

            return randomValue switch
                   {
                       <= 20 => new Wheat(position),
                       >20 => new Soil(position)
                   };
        }
    }
}