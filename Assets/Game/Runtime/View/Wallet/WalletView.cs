using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Runtime.View.Wallet
{
    public class WalletView : MonoBehaviour, IWalletView
    {
        [SerializeField] private TMP_Text _money;

        private readonly Dictionary<int, string> _postfixes = new()
        {
            {1000000, "M"},
            {1000, "k"}
        };
        
        public void DisplayMoney(int amount)
        {
            var totalPostfix = "";
            float totalAmount = amount;
            
            foreach (var (money, postfix) in _postfixes)
            {
                var value = (float) amount / money;
                if (value >= 1f)
                {
                    totalAmount = value;
                    totalPostfix = postfix;
                    break;
                }
            }

            _money.text = $"{totalAmount}{totalPostfix}";
        }
    }
}