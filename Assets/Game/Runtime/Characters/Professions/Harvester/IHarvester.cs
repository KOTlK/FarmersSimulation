using Game.Runtime.Environment.Crops;
using Game.Runtime.Resources;

namespace Game.Runtime.Characters.Professions.Harvester
{
    public interface IHarvester : IFriendlyCharacter, IWorker
    {
        bool InventoryFull { get; }
        bool HasResourceCollected { get; }
        void Harvest(ICollectable collectable);
        void EmptyPockets(IResourcesStorage targetStorage);
    }
}