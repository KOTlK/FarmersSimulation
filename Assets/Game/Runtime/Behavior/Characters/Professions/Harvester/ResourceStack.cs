using System;
using System.Collections.Generic;
using Game.Runtime.Environment;
using Game.Runtime.Environment.Crops;

namespace Game.Runtime.Behavior.Characters.Professions.Harvester
{
    public class ResourceStack<T> : IResourceStack<T>, IDisposable
    where T : IRecoverable<T>
    {
        private readonly IEnumerable<T> _resources;
        private readonly Stack<T> _stack;

        public ResourceStack(IEnumerable<T> resources)
        {
            _stack = new Stack<T>();
            _resources = resources;

            foreach (var resource in _resources)
            {
                resource.Recovered += Push;
            }
        }

        public bool HasResource => _stack.Count > 0;
        public T Pop() => _stack.Pop();

        public void Dispose()
        {
            foreach (var resource in _resources)
            {
                resource.Recovered -= Push;
            }
        }
        
        private void Push(T resource)
        {
            _stack.Push(resource);
        }

        
    }
}