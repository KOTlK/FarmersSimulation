using System;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.View.Field;
using UnityEngine;

namespace Game.Runtime.Rendering.Tiles
{
    [Serializable]
    public class TileByType
    {
        [field: SerializeField] public TileType Type { get; private set; }
        [field: SerializeField] public Tile Prefab { get; private set; }
    }
}