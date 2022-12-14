using System;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.TileMap.Tiles.TileTypes;
using UnityEngine;

namespace Game.Runtime.TileMap.Pathfinding
{
    [CreateAssetMenu(menuName = "ScriptableHell/TilesCosts", fileName = "TilesCosts")]
    public class TilesCosts : ScriptableObject, ICost
    {
        [SerializeField] private double _grass = 1,
                                        _rock = 1,
                                        _soil = 2,
                                        _chest = 2,
                                        _empty = double.MaxValue,
                                        _factory = 10,
                                        _wheat = 3;
        public double TileCost(ITile tile)
        {
            return tile switch
            {
                Grass grass => _grass,
                Rock rock => _rock,
                Soil soil => _soil,
                Chest chest => _chest,
                Empty empty => _empty,
                Factory factory => _factory,
                Wheat wheat => _wheat,
                _ => throw new ArgumentOutOfRangeException(nameof(tile))
            };
        }
    }
}