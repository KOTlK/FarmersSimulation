using System.Collections;
using System.Collections.Generic;
using Game.Runtime.Factories;
using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap.Tiles.TileTypes;
using Factory = Game.Runtime.TileMap.Tiles.TileTypes.Factory;

namespace Game.Runtime.TileMap.Tiles
{
    public class FactoryBlueprint : ITileBlueprint
    {
        private readonly Factory _factory;
        private readonly List<ITile> _list;

        public FactoryBlueprint(ITile origin, IBlueprint factoryBlueprint, ITileMap tileMap)
        {
            var factory = new Factory(origin, factoryBlueprint);
            
            _list = new List<ITile>(new ITile[]
            {
               factory,
               new FactoryPart(tileMap[origin.Position + new Vector2Int(1, 0)], TileType.FactoryPart0),
               new FactoryPart(tileMap[origin.Position + new Vector2Int(2, 0)], TileType.FactoryPart1),
               new FactoryPart(tileMap[origin.Position + new Vector2Int(0, 1)], TileType.FactoryPart2),
               new FactoryPart(tileMap[origin.Position + new Vector2Int(1, 1)], TileType.FactoryPart3),
               new FactoryPart(tileMap[origin.Position + new Vector2Int(2, 1)], TileType.FactoryPart4),
               new FactoryPart(tileMap[origin.Position + new Vector2Int(0, 2)], TileType.FactoryPart5),
               new FactoryPart(tileMap[origin.Position + new Vector2Int(1, 2)], TileType.FactoryPart6),
               new FactoryPart(tileMap[origin.Position + new Vector2Int(2, 2)], TileType.FactoryPart7)
            });
        }

        public IEnumerator<ITile> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}