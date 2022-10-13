using System;
using System.Collections.Generic;
using Game.Runtime.Inventory;

namespace Game.Runtime.View.Storage
{
    public interface IStorageView
    {
        void DisplayStorage(IEnumerable<IItem> items);
    }
}