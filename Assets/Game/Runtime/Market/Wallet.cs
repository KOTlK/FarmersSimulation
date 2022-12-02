using System;
using Game.Runtime.View.Wallet;

namespace Game.Runtime.Market
{
    public class Wallet : IWallet
    {
        private int _value;

        public Wallet() : this(0)
        {
        }

        public Wallet(int startAmount)
        {
            _value = startAmount;
        }

        public void Visualize(IWalletView view)
        {
            view.DisplayMoney(_value);
        }

        public bool CanSpend(int amount)
        {
            return _value >= amount;
        }

        public void Transfer(IWallet wallet, int amount)
        {
            if (amount > _value)
                throw new ArgumentException(nameof(amount));

            _value -= amount;
            wallet.Put(amount);
        }

        public void Spend(int amount)
        {
            if (amount > _value)
                throw new ArgumentException(nameof(amount));

            _value -= amount;
        }

        public void Put(int amount)
        {
            _value += amount;
        }
    }
}