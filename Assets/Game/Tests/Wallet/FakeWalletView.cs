using Game.Runtime.View.Wallet;

namespace Game.Tests.Wallet
{
    public class FakeWalletView : IWalletView
    {
        public int CurrentAmount = 0;
        public void DisplayMoney(int amount)
        {
            CurrentAmount = amount;
        }
    }
}