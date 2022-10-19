using BananaParty.BehaviorTree;
using Game.Runtime.Behavior;
using Game.Runtime.Behavior.Session;
using Game.Runtime.Behavior.Session.View;
using Game.Runtime.Characters;
using Game.Runtime.Input.Characters;
using Game.Runtime.Input.View;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Session
{
    public class Session : ISession
    {
        private readonly IBehaviorNode _behavior;
        
        public Session(IUserInterfaceRoot ui, IClickInputs<ICharacter> characterInputs, IClickedCharacter clickedCharacter)
        {
            UI = ui;

            _behavior = new SelectorNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new IsButtonClickedNode(ui.CharacterInfoPanel.CloseButton),
                    new DeactivateElementNode(ui.CharacterInfoPanel)
                }),
                
                new SelectorNode(new IBehaviorNode[]
                {
                    new SequenceNode(new IBehaviorNode[]
                    {
                        new IsCharacterClickedNode(characterInputs, clickedCharacter),
                        new ActivateElementNode(ui.CharacterInfoPanel)
                    }),
                
                    new SequenceNode(new IBehaviorNode[]
                    {
                        new IsElementActiveNode(ui.CharacterInfoPanel),
                        new RenderNode<ICharacter, ICharacterView>(clickedCharacter, ui.CharacterInfoPanel.CharacterView)
                    })
                })
            }).Repeat();
        }

        public IUserInterfaceRoot UI { get; }
        
        public void Execute(long time)
        {
            _behavior.Execute(time);
        }

        public void Visualize(ITreeGraph<IReadOnlyBehaviorNode> view)
        {
            _behavior.WriteToGraph(view);
        }
    }
}