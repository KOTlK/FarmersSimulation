using BananaParty.BehaviorTree;
using UnityEditor;

namespace Game.Runtime.Behavior.Application
{
    public class ExitGameNode : BehaviorNode
    {
        public override BehaviorNodeStatus OnExecute(long time)
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif
            UnityEngine.Application.Quit();

            return BehaviorNodeStatus.Success;
        }
    }
}