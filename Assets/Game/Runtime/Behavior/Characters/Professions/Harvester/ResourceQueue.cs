using System;
using System.Collections.Generic;
using Game.Runtime.Environment;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class ResourceQueue<T> : IResourceStack<T>, IDisposable
    where T : IRecoverable<T>
    {
        private readonly IEnumerable<T> _resources;
        private readonly Queue<T> _stack;

        public ResourceQueue(IEnumerable<T> resources)
        {
            _stack = new Queue<T>();
            _resources = resources;

            foreach (var resource in _resources)
            {
                resource.Recovered += Push;
            }
        }

        public bool HasResource => _stack.Count > 0;
        public T Pop() => _stack.Dequeue();

        public void Dispose()
        {
            foreach (var resource in _resources)
            {
                resource.Recovered -= Push;
            }
        }
        
        private void Push(T resource)
        {
            _stack.Enqueue(resource);
        }
    }
}