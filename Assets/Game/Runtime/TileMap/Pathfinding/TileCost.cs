using System;
using Game.Runtime.TileMap.Tiles;
using UnityEngine;

namespace Game.Runtime.TileMap.Pathfinding
{
    [Serializable]
    public class TileCost
    {
        [field : SerializeField] public TileType Type { get; private set; }
        [field : SerializeField] public double Cost { get; private set; }
    }
}