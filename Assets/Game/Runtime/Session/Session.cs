using System;
using BananaParty.BehaviorTree;
using Game.Runtime.Application;
using Game.Runtime.Behavior;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Behavior.Characters.Professions.Farmer;
using Game.Runtime.Behavior.Session;
using Game.Runtime.Behavior.Session.View;
using Game.Runtime.Characters;
using Game.Runtime.Characters.Professions.Farmer;
using Game.Runtime.Input.Characters;
using Game.Runtime.Input.View;
using Game.Runtime.Random;
using Game.Runtime.Resources;
using Game.Runtime.View.Characters;
using Game.Runtime.View.Storage;
using UnityEngine;

namespace Game.Runtime.Session
{
    public class Session : ISession
    {
        private readonly IBehaviorNode _behavior;
        
        public Session(IUserInterfaceRoot ui, SceneData sceneData)
        {
            UI = ui;
            var selectedCharacter = new SelectedCharacter();
            var randomName = new RandomName(sceneData.Names.text);
            var randomAge = new RandomAge(18, 70);

            foreach (var character in sceneData.Characters)
            {
                IBehavior behavior = character.Profession switch
                {
                    Profession.Civilian => new Civilian(character),
                    Profession.Farmer => new FarmerBehavior((IFarmer)character, sceneData.Plants, sceneData.Storage),
                    Profession.Miner => throw new NotImplementedException(),
                    Profession.Warrior => throw new NotImplementedException(),
                    _ => throw new NotImplementedException()
                };

                character.Initialize(randomName, randomAge, behavior);
            }

            _behavior = new ParallelSequenceNode(new IBehaviorNode[]
            {
                new ExecuteBehaviorsNode(sceneData.Characters),
                
                new ParallelSelectorNode(new IBehaviorNode[]
                {
                    new SelectorNode(new IBehaviorNode[]
                    {
                        new SequenceNode(new IBehaviorNode[]
                        {
                            new IsCharacterClickedNode(sceneData.CharacterInputs, selectedCharacter),
                            new ActivateElementNode(ui.CharacterInfoElement)
                        }),
                        
                        new SequenceNode(new IBehaviorNode[]
                        {
                            new IsElementActiveNode(ui.CharacterInfoElement),
                            new ParallelSequenceNode(new IBehaviorNode[]
                            {
                                new WaitButtonClickNode(ui.CharacterInfoElement.CloseButton).Invert(),
                                new RenderNode<ICharacter, ICharacterView>(selectedCharacter, ui.CharacterInfoElement.CharacterView),
                                new WaitCharacterClickNode(selectedCharacter, sceneData.CharacterInputs)
                            }).RepeatUntilFailure().Invert(),
                            new DeactivateElementNode(ui.CharacterInfoElement)
                        })
                    }),
                    
                    new SelectorNode(new IBehaviorNode[]
                    {
                        new SequenceNode(new IBehaviorNode[]
                        {
                            new IsElementClickedNode<IWorldStorage>(sceneData.StorageInputs),
                            new ActivateElementNode(ui.StorageElement)
                        }),
                        
                        new SequenceNode(new IBehaviorNode[]
                        {
                            new IsElementActiveNode(ui.StorageElement),
                            new ParallelSequenceNode(new IBehaviorNode[]
                            {
                                new WaitButtonClickNode(ui.StorageElement.CloseButton).Invert(),
                                new RenderNode<IWorldStorage, IResourceStorageView>(sceneData.Storage, ui.StorageElement)
                            }).RepeatUntilFailure().Invert(),
                            new DeactivateElementNode(ui.StorageElement)
                        })
                    })
                }, "UI ")
                
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