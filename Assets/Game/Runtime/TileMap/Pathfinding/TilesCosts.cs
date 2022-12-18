using System;
using System.Collections.Generic;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.TileMap.Tiles.TileTypes;
using UnityEngine;

namespace Game.Runtime.TileMap.Pathfinding
{
    [CreateAssetMenu(menuName = "ScriptableHell/TilesCosts", fileName = "TilesCosts")]
    public class TilesCosts : ScriptableObject, ICost
    {
        [SerializeField] private TileCost[] _costs;

        private readonly Dictionary<TileType, double> _dictionary = new();

        public void Init()
        {
            foreach (var cost in _costs)
            {
                _dictionary.Add(cost.Type, cost.Cost);
            }
        }
        
        public double TileCost(ITile tile)
        {
            return tile switch
            {
                Grass => _dictionary[TileType.Grass],
                Rock => _dictionary[TileType.Rock],
                Soil => _dictionary[TileType.Soil],
                Chest => _dictionary[TileType.Chest],
                Empty => _dictionary[TileType.Empty],
                Factory => _dictionary[TileType.Factory],
                FactoryPart => _dictionary[TileType.Factory],
                Wheat => _dictionary[TileType.WheatGrown],
                CopperMine => _dictionary[TileType.CopperMine],
                SilverMine => _dictionary[TileType.SilverMine],
                IronMine => _dictionary[TileType.IronMine],
                GoldMine => _dictionary[TileType.GoldMine],
                _ => throw new ArgumentOutOfRangeException(nameof(tile))
            };
        }
    }
}