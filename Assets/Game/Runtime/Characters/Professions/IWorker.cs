using Game.Runtime.Market;

namespace Game.Runtime.Characters.Professions
{
    public interface IWorker
    {
        int CalculateSalary(IMarket market);
        void PaySalary(int salary);
    }
}