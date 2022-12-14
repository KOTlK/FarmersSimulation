using System.Collections.Generic;
using Game.Runtime.Characters.Professions;

namespace Game.Runtime.Market.Employers
{
    public class Factory : IEmployer
    {
        private readonly IWallet _budget = new Wallet(1000000);
        private readonly List<IWorker> _employees = new();
        private readonly IMarket _market = new Market();
        
        public void PaySalary()
        {
            foreach (var employee in _employees)
            {
                var salary = employee.CalculateSalary(_market);
                _budget.Spend(salary);
                employee.PaySalary(salary);
            }
        }

        public void AddEmployee(IWorker worker) => _employees.Add(worker);

        public void RemoveEmployee(IWorker worker) => _employees.Remove(worker);
    }
}