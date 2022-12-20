using System;
using System.Collections.Generic;
using System.Linq;
using Game.Runtime.Math.Vectors;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Session;
using Game.Runtime.TileMap.Pathfinding;
using Game.Runtime.TileMap.Tiles.TileTypes;
using Game.Runtime.View.TileGraph;

namespace Game.Runtime.TileMap
{
    public class TileMap : ITileMap
    {
        private readonly int _length;
        private readonly int _height;
        private readonly ITile[,] _tiles;
        private readonly List<IGameLoop> _executionLoop = new();
        private readonly List<ITile> _renderLoop = new();
        private readonly Queue<ITile> _renderQueue = new();
        private readonly IGraph _graph;
        private readonly IAlgorithm _pathfinding;
        private readonly Dictionary<Type, List<ITile>> _tilesByType = new();
        private readonly RandomDirection _random = new();

        public TileMap(ITile[,] tiles, ICost walkCosts)
        {
            _length = tiles.GetLength(0) - 1;
            _height = tiles.GetLength(1) - 1;
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

                if (_tilesByType.ContainsKey(tile.GetType()) == false)
                    _tilesByType.Add(tile.GetType(), new List<ITile>());

                _tilesByType[tile.GetType()].Add(tile);
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

        public bool Contains(Vector2Int position)
        {
            return position.X > 0 &&
                   position.X < _length &&
                   position.Y > 0 &&
                   position.Y < _height;
        }

        public Vector2Int PointAround(Vector2Int position)
        {
            var point = position + _random.Next();
            var x = point.X;
            var y = point.Y;

            if (x > _length)
                x = _length;

            if (x < 0)
                x = 0;

            if (y > _height)
                y = _height;

            if (y < 0)
                y = 0;

            return new Vector2Int(x, y);
        }

        public void Replace(Vector2Int position, ITile tile)
        {
            var previousTile = _tiles[position.X, position.Y];

            RemoveTile(previousTile);
                
            _tiles[position.X, position.Y] = tile;
            _graph.Recalculate(position, tile);
            _renderQueue.Enqueue(tile);

            var type = tile.GetType();

            if (_tilesByType.ContainsKey(type) == false)
            {
                _tilesByType.Add(type, new List<ITile>(new []{tile}));
            }
            else
            {
                _tilesByType[type].Add(tile);
            }

            if (tile is IGameLoop loop)
            {
                _executionLoop.Add(loop);
                _renderLoop.Add(tile);
            }
        }

        public IEnumerable<T> GetTiles<T>() => _tilesByType[typeof(T)].Cast<T>();

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

        private void RemoveTile(ITile tile)
        {
            if (tile is Decorator decorator)
            {
                RemoveTile(decorator.Origin);
            }
            
            if (tile is IGameLoop previous)
            {
                _executionLoop.Remove(previous);
                _renderLoop.Remove(tile);
            }

            if (tile is IDisposable disposable)
            {
                disposable.Dispose();
            }

            var list = _tilesByType[tile.GetType()];

            if (list.Contains(tile))
            {
                list.Remove(tile);
            }
        }
    }
}