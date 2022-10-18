using Game.Runtime.Resources;

namespace Game.Runtime.Environment.Crops
{
    public interface ICollectable
    {
        bool ReadyForGather { get; }
        void Gather(IResourcesStorage storage);
    }
}