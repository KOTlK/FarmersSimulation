using Game.Runtime.Factories;
using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap.Pathfinding;

namespace Game.Runtime.TileMap.Tiles
{
    public class TileMapFactory : IFactory<ITileMap>
    {
        private readonly Vector2Int _size;
        private readonly ITileRule _tileRule;
        private readonly ICost _tileCosts;

        public TileMapFactory(Vector2Int size, ITileRule tileRule, ICost tileCosts)
        {
            _size = size;
            _tileRule = tileRule;
            _tileCosts = tileCosts;
        }

        public ITileMap Create()
        {
            var tiles = new ITile[_size.X, _size.Y];

            for (var y = 0; y < _size.Y; y++)
            {
                for(var x = 0; x < _size.X; x++)
                {
                    tiles[x, y] = _tileRule.Next(new Vector2Int(x, y));
                }
            }

            return new TileMap(tiles, _tileCosts);
        }
    }
}