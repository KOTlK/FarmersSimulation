using Game.Runtime.View;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Resources
{
    public interface IResourcesStorage : IVisualization<IResourceStorageView>
    {
        bool HasResource(Resource resource, int amount = 1);
        int Count(Resource resource);
        bool EnoughSpace(int amount);
        bool IsFull { get; }
        void Put(Resource resource, int amount = 1);
        void Remove(Resource resource, int amount = 1);
    }
}