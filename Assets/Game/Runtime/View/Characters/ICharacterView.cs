using Game.Runtime.Behavior.Characters.Professions;

namespace Game.Runtime.View.Characters
{
    public interface ICharacterView : IAgeView, IProfessionView, INameView
    {
        void DisplayBehavior(IBehavior behavior);
    }
}