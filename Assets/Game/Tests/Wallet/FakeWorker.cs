using Game.Runtime.Characters.Professions;
using Game.Runtime.Market;

namespace Game.Tests.Wallet
{
    public class FakeWorker : IWorker
    {
        private readonly int _salary;
        private readonly IWallet _wallet;

        public FakeWorker(int salary, IWallet wallet)
        {
            _salary = salary;
            _wallet = wallet;
        }

        public int CalculateSalary(IMarket market)
        {
            return _salary;
        }

        public void PaySalary(int salary)
        {
            _wallet.Put(salary);
        }
    }
}