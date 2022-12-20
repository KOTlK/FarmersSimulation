using System.Collections.Generic;
using Game.Runtime.Characters.Professions;
using Game.Runtime.TileMap.Tiles;

namespace Game.Runtime.Market.Employers
{
    public class Farm : IFarm
    {
        private readonly List<ITile> _property = new();
        private readonly List<IWorker> _employees = new();
        private readonly IMarket _market;

        public Farm(IMarket market)
        {
            _market = market;
        }

        public void PaySalary()
        {
            foreach (var employee in _employees)
            {
                employee.PaySalary(employee.CalculateSalary(_market));
            }
        }

        public void AddEmployee(IWorker worker) => _employees.Add(worker);

        public void RemoveEmployee(IWorker worker)
        {
            if (_employees.Contains(worker))
                _employees.Remove(worker);
        }

        public void AddField(ITile tile) => _property.Add(tile);
    }
}