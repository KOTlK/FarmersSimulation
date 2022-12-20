using BananaParty.BehaviorTree;
using Game.Runtime.Characters;

namespace Game.Runtime.Behavior.Characters.Professions
{
    public interface IBehaviorsFactory
    {
        IBehaviorNode Create(Profession type, ICharacter target);
    }
}