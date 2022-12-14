using System.Collections.Generic;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Session;
using Game.Runtime.TileMap.Pathfinding;
using Game.Runtime.View.TileGraph;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.TileMap
{
    public class TileMap : ITileMap
    {
        private readonly ITile[,] _tiles;
        private readonly List<IGameLoop> _executionLoop = new();
        private readonly List<ITile> _renderLoop = new();
        private readonly Queue<ITile> _renderQueue = new();
        private readonly IGraph _graph;
        private readonly IAlgorithm _pathfinding;

        public TileMap(ITile[,] tiles, ICost walkCosts)
        {
            _tiles = tiles;
            Size = new Vector2Int(tiles.GetLength(0), tiles.GetLength(1));
            foreach (var tile in tiles)
            {
                _renderQueue.Enqueue(tile);
                if (tile is IGameLoop loop)
                {
                    _executionLoop.Add(loop);
                    _renderLoop.Add(tile);
                }
            }

            _graph = new Graph(tiles, walkCosts);
            _pathfinding = new AStar(new Heuristic(), _graph);
        }
        
        public Vector2Int Size { get; }

        public void Execute(long time)
        {
            foreach (var tile in _executionLoop)
            {
                tile.Execute(time);
            }
        }
        
        public ITile this[Vector2Int position] => _tiles[position.X, position.Y];

        public void Replace(Vector2Int position, ITile tile)
        {
            var previousTile = _tiles[position.X, position.Y];
            if (previousTile is IGameLoop previous)
            {
                _executionLoop.Remove(previous);
                _renderLoop.Remove(previousTile);
            }
                
            _tiles[position.X, position.Y] = tile;
            _graph.Recalculate(position, tile);
            _renderQueue.Enqueue(tile);
                
            if (tile is IGameLoop loop)
            {
                _executionLoop.Add(loop);
                _renderLoop.Add(tile);
            }
        }

        public void Visualize(ITileMapRenderer view)
        {
            foreach (var tile in _renderLoop)
            {
                tile.Visualize(view);
            }

            while (_renderQueue.Count > 0)
            {
                _renderQueue.Dequeue().Visualize(view);
            }
        }

        public void Visualize(ITileGraphView view) => _graph.Visualize(view);
        
        public IPath FindPath(Vector2Int from, Vector2Int to) => _pathfinding.FindPath(from, to);
    }
}