using System;
using Game.Runtime.TileMap.Tiles.TileTypes;
using UnityEngine;
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
                > 0.6f => RockOrMine(position),
                _ => throw new ArgumentOutOfRangeException(nameof(noise), noise, null)
            };
        }

        private ITile WheatOrSoil(Vector2Int position)
        {
            var randomValue = _random.Next(0, 100);

            return randomValue switch
                   {
                       <= 20 => new Wheat(new Soil(position)),
                       >20 => new Soil(position)
                   };
        }

        private ITile RockOrMine(Vector2Int position)
        {
            var value = _random.Next(0, 100);

            return value switch
            {
                <= 5 => RandomMine(position),
                _ => new Rock(position)
            };
        }

        private ITile RandomMine(Vector2Int position)
        {
            var random = _random.Next(0, 100);

            return random switch
            {
                <= 5 => new GoldMine(new Rock(position)),
                <= 8 => new SilverMine(new Rock(position)),
                <= 30 => new IronMine(new Rock(position)),
                _ => new CopperMine(new Rock(position))
            };
        }
    }
}