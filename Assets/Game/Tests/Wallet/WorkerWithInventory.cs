using Game.Runtime.Characters.Professions;
using Game.Runtime.Market;
using Game.Runtime.Resources;

namespace Game.Tests.Wallet
{
    public class WorkerWithInventory : IWorker
    {
        private readonly IResourceStorage _inventory;
        private readonly IWallet _wallet;

        public WorkerWithInventory(IResourceStorage inventory, IWallet wallet)
        {
            _inventory = inventory;
            _wallet = wallet;
        }

        public int CalculateSalary(IMarket market)
        {
            return _inventory.CalculateCost(market);
        }

        public void PaySalary(int salary)
        {
            _wallet.Put(salary);
        }
    }
}