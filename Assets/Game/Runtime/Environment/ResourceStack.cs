using System;
using System.Collections.Generic;

namespace Game.Runtime.Environment
{
    public class ResourceStack<T> : IResourceStack<T>
    where T : IRecoverable<T>
    {
        private readonly Stack<T> _ready = new();

        public ResourceStack(IEnumerable<T> resources)
        {
            foreach (var resource in resources)
            {
                resource.Recovered += _ready.Push;
            }
        }

        public bool HasResource => _ready.Count > 0;
        public T Pop()
        {
            if (HasResource == false)
                throw new Exception("No ready resources");

            return _ready.Pop();
        }
    }
}