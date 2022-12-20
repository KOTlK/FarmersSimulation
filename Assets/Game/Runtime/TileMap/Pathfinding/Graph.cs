using System.Collections.Generic;
using System.Linq;
using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.View.TileGraph;

namespace Game.Runtime.TileMap.Pathfinding
{
    public sealed class Graph : IGraph
    {
        private readonly Dictionary<Vector2Int, IEnumerable<Vector2Int>> _neighbours = new();
        private readonly Dictionary<(Vector2Int, Vector2Int), double> _costs = new();
        private readonly ICost _tileCosts;

        private readonly Vector2Int[] _offsets = new[]
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 1),
            new Vector2Int(1, 0),
            new Vector2Int(1, -1),
            new Vector2Int(0, -1),
            new Vector2Int(-1, -1),
            new Vector2Int(-1, 0),
            new Vector2Int(-1, 1)
        };

        public Graph(ITile[,] tiles, ICost costs)
        {
            _tileCosts = costs;
            var length = tiles.GetLength(0);
            var height = tiles.GetLength(1);

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < length; x++)
                {
                    var currentPosition = new Vector2Int(x, y);

                    var neighbours = (from offset in _offsets 
                                      select currentPosition + offset 
                                      into neighbour 
                                      where neighbour.X >= 0 && neighbour.Y >= 0 
                                      where neighbour.X <= length - 1 
                                      where neighbour.Y <= height - 1 
                                      select neighbour).
                                     Cast<Vector2Int>().
                                     ToList();

                    _neighbours.Add(currentPosition, neighbours);
                }
            }

            foreach (var position in _neighbours.Keys)
            {
                foreach (var neighbour in _neighbours[position])
                {
                    var cost = costs.TileCost(tiles[neighbour.X, neighbour.Y]);
                    _costs[(position, neighbour)] = cost;
                }
            }
        }

        public IEnumerable<Vector2Int> Neighbours(Vector2Int nodePosition) => _neighbours[nodePosition];
        
        public void Recalculate(Vector2Int position, ITile tile)
        {
            RecalculateCostsInPosition(position, tile);
        }

        public double Cost(Vector2Int from, Vector2Int to) => _costs[(from, to)];

        public void Visualize(ITileGraphView view)
        {
            foreach (var (position, neighbours) in _neighbours)
            {
                foreach (var neighbour in neighbours)
                {
                    view.DisplayDirection(position, neighbour);
                }
            }
        }

        private void RecalculateNeighboursInArea(Vector2Int position)
        {
            foreach (var offset in _offsets)
            {
                var neighbour = position + offset;

                if (_neighbours.ContainsKey(neighbour))
                {
                    _neighbours[neighbour] = CalculateNeighboursIn(neighbour);
                }
            }
        }

        private IEnumerable<Vector2Int> CalculateNeighboursIn(Vector2Int position)
        {
            return _offsets
                  .Select(offset => position + offset)
                  .Where(nextPosition => _neighbours.ContainsKey(nextPosition))
                  .Cast<Vector2Int>().ToList();
        }

        private void RecalculateCostsInPosition(Vector2Int position, ITile newTile)
        {
            foreach (var neighbour in _neighbours[position])
            {
                var cost = _tileCosts.TileCost(newTile);
                _costs[(position, neighbour)] = cost;
            }
        }
    }
}