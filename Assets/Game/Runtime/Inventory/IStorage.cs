using Game.Runtime.View;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Inventory
{
    public interface IStorage : IVisualization<IStorageView>
    {
        bool IsFull { get; }
        bool HasItem<TItem>();
        void Put<TItem>(IItem item);
        TItem Take<TItem>();
    }
}