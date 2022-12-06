using System.Collections.Generic;
using BananaParty.BehaviorTree;
using Game.Runtime.Market;
using UnityEngine;

namespace Game.Runtime.Behavior.Factories
{
    public class PayMonthlySalaryNode : BehaviorNode
    {
        private readonly IEnumerable<IEmployer> _employers;

        public PayMonthlySalaryNode(IEnumerable<IEmployer> employers)
        {
            _employers = employers;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            foreach (var employer in _employers)
            {
                employer.PaySalary();
                Debug.Log("Salary paid");
            }

            return BehaviorNodeStatus.Success;
        }
    }
}