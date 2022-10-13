using Game.Runtime.Environment.Crops;
using Game.Runtime.Inventory;
using Game.Runtime.View;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Characters.Professions.Farmer
{
    public interface IFarmer : ICharacter, IVisualization<IStorageView>
    {
        bool InventoryFull { get; }
        bool HasCollectedPlants { get; }
        void GatherPlant(ICollectable plant);
        void EmptyPockets(IStorage targetStorage);
    }
}