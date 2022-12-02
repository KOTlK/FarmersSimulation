using Game.Runtime.Characters.Professions;

namespace Game.Runtime.Market
{
    public interface IEmployer
    {
        void PaySalary();
        void AddEmployee(IWorker worker);
        void RemoveEmployee(IWorker worker);
    }
}