using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.View.Wallet;

namespace Game.Runtime.View.Characters
{
    public interface ICharacterView : IAgeView, INameView, IProfessionView, IWalletView
    {
        void DisplayBehavior(IBehavior behavior);
    }
}