using System.Collections.Generic;
using Game.Runtime.Resources;

namespace Game.Runtime.View.Storage
{
    public interface IResourceStorageView
    {
        void DisplayStorage(Dictionary<Resource, int> resources);
    }
}