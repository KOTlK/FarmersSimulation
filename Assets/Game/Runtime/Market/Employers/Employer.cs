using System.Collections.Generic;
using Game.Runtime.Characters;
using Game.Runtime.Characters.Professions;
using UnityEngine;

namespace Game.Runtime.Market.Employers
{
    public class Employer : MonoBehaviour, IEmployer
    {
        [SerializeField] private Character[] _workers;
        
        private List<IWorker> _employees;
        private readonly IMarket _market = new Market();

        private void Awake()
        {
            _employees = new List<IWorker>(_workers);
        }

        public void PaySalary()
        {
            foreach (var worker in _employees)
            {
                worker.PaySalary(worker.CalculateSalary(_market));
            }
        }

        public void AddEmployee(IWorker worker)
        {
            _employees.Add(worker);
        }

        public void RemoveEmployee(IWorker worker)
        {
            if (_employees.Contains(worker))
            {
                _employees.Remove(worker);
            }
        }
    }
}