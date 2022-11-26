using Game.Runtime.Behavior.Characters.Professions;

namespace Game.Runtime.View.Characters
{
    public interface IFriendlyCharacterView : IAgeView, INameView, IProfessionView
    {
        void DisplayBehavior(IBehavior behavior);
    }
}