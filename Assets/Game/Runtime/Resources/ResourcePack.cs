using System.Collections.Generic;

namespace Game.Runtime.Resources
{
    public class ResourcePack : IResourcePack
    {
        private readonly List<(Resource, int)> _resources;
        
        public ResourcePack(IEnumerable<(Resource, int)> resource)
        {
            _resources = new List<(Resource, int)>(resource);
        }

        public void Transfer(IResourceStorage storage)
        {
            foreach (var (resource, amount) in _resources)
            {
                storage.Put(resource, amount);
            }
        }
    }
}