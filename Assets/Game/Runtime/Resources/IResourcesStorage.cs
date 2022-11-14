using System.Collections.Generic;
using Game.Runtime.View;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Resources
{
    public interface IResourcesStorage : IReadonlyResourceStorage, IVisualization<IResourceStorageView>
    {
        void Put(Resource resource, int amount = 1);
        /// <summary>
        /// Take specific amount of resource
        /// </summary>
        IResourcePack Take(Resource resource, int amount = 1);
        /// <summary>
        /// Take specific amount of specific resource
        /// </summary>
        /// <param name="resources">List of resources and amounts</param>
        IResourcePack Take(IEnumerable<(Resource, int)> resources);
        /// <summary>
        /// Take all specific resources
        /// </summary>
        /// <param name="resources">List of resources</param>
        IResourcePack Take(IEnumerable<Resource> resources);
        /// <summary>
        /// Take all resources from storage
        /// </summary>
        IResourcePack Take();
    }
}