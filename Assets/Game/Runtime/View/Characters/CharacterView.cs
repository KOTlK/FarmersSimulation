using Game.Runtime.Behavior;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Characters;
using Game.Runtime.View.Wallet;
using TMPro;
using UnityEngine;

namespace Game.Runtime.View.Characters
{
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private WalletView _wallet;
        [SerializeField] private TMP_Text _name, _age, _profession;
        [SerializeField] private TreeVisualization _behavior;
        
        public void DisplayAge(float age)
        {
            _age.text = age.ToString();
        }

        public void DisplayProfession(Profession profession)
        {
            _profession.text = profession.ToString();
        }

        public void DisplayName(string characterName)
        {
            _name.text = characterName;
        }

        public void DisplayBehavior(IBehavior behavior)
        {
            behavior.Visualize(_behavior);
            _behavior.Visualize();
        }

        public void DisplayMoney(int amount) => _wallet.DisplayMoney(amount);
    }
}