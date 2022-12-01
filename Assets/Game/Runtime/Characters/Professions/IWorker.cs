using Game.Runtime.Market;

namespace Game.Runtime.Characters.Professions
{
    public interface IWorker
    {
        float Salary(IMarket market, IEmployer employer);
    }
}