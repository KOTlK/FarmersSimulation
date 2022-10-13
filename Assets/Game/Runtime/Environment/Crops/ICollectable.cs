using Game.Runtime.Inventory;

namespace Game.Runtime.Environment.Crops
{
    public interface ICollectable
    {
        bool ReadyForGather { get; }
        void Gather(IStorage storage);
    }
}