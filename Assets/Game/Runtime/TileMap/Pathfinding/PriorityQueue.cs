using System;
using System.Collections.Generic;

namespace Game.Runtime.TileMap.Pathfinding
{
    public class PriorityQueue<T>
    {
        private readonly List<Tuple<T, double>> _elements = new();

        public int Count => _elements.Count;

        public void Enqueue(T item, double priority)
        {
            _elements.Add(Tuple.Create(item, priority));
        }

        public T Dequeue()
        {
            var bestIndex = 0;

            for (var index = 0; index < _elements.Count; index++)
            {
                if (_elements[index].Item2 < _elements[bestIndex].Item2)
                {
                    bestIndex = index;
                }
            }

            var bestItem = _elements[bestIndex].Item1;
            _elements.RemoveAt(bestIndex);
            return bestItem;
        }
    }
}