using System.Collections.Generic;
using Game.Runtime.View;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Resources
{
    public interface IResourcesStorage : IReadonlyResourceStorage, IVisualization<IResourceStorageView>
    {
        void Put(Resource resource, int amount = 1);
        IResourcePack Take(Resource resource, bool removeAll = false, int amount = 1);
        IResourcePack Take(IEnumerable<(Resource, int)> resources);
        IResourcePack Take(IEnumerable<Resource> resources);
    }
}