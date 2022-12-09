using Game.Runtime.Market;
using Game.Runtime.Resources;
using NUnit.Framework;

namespace Game.Tests.Wallet
{
    public class WalletTests
    {
        [Test]
        public void SalaryWillBePaid()
        {
            var wallet = new Runtime.Market.Wallet(100);
            var view = new FakeWalletView();

            wallet.Visualize(view);

            Assert.True(view.CurrentAmount == 100);

            var worker = new FakeWorker(100, wallet);

            worker.PaySalary(worker.CalculateSalary(new Market()));

            wallet.Visualize(view);

            Assert.True(view.CurrentAmount == 200);
        }

        [Test]
        public void InventoryWillCalculateSalary()
        {
            var resources = new ResourceStorage(1000);
            var wallet = new Runtime.Market.Wallet(0);
            var view = new FakeWalletView();
            var worker = new WorkerWithInventory(resources, wallet);
            var market = new FakeMarket(100);

            resources.Put(Resource.Wheat, 10);

            worker.PaySalary(worker.CalculateSalary(market));
            wallet.Visualize(view);

            Assert.True(view.CurrentAmount == 1000);
        }
    }
}