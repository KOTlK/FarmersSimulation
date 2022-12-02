using Game.Runtime.View;
using Game.Runtime.View.Wallet;

namespace Game.Runtime.Market
{
    public interface IWallet : IVisualization<IWalletView>
    {
        bool CanSpend(int amount);
        void Transfer(IWallet wallet, int amount);
        void Spend(int amount);
        void Put(int amount);
    }
}