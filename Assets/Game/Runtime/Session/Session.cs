using System;
using BananaParty.BehaviorTree;
using Game.Runtime.DateTime;
using Game.Runtime.Application;
using Game.Runtime.Behavior;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Behavior.Characters.Professions.Harvester;
using Game.Runtime.Behavior.Factories;
using Game.Runtime.Behavior.Session;
using Game.Runtime.Behavior.Session.View;
using Game.Runtime.Behavior.Time;
using Game.Runtime.Characters;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Environment.Mines;
using Game.Runtime.Input.Characters;
using Game.Runtime.Input.View;
using Game.Runtime.Random;
using Game.Runtime.Resources;
using Game.Runtime.View.Characters;
using Game.Runtime.View.DateTime;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Session
{
    public class Session : ISession
    {
        private readonly IBehaviorNode _behavior;
        
        public Session(IUserInterfaceRoot ui, SceneData sceneData)
        {
            UI = ui;
            var selectedCharacter = new CharacterSelector();
            var randomName = new RandomName(sceneData.Names.text);
            var randomAge = new RandomAge(18, 70);
            IDateTime dateTime;

            foreach (var character in sceneData.Characters)
            {
                IBehavior behavior = character.Profession switch
                {
                    Profession.Civilian => new CivilianBehavior(character),
                    Profession.Farmer => new HarvesterBehavior<IPlant>(character, sceneData.Plants, sceneData.Storage),
                    Profession.Miner => new HarvesterBehavior<IMine>(character, sceneData.Mines, sceneData.Storage),
                    _ => throw new NotImplementedException()
                };

                character.Initialize(randomName, randomAge, behavior);
            }

            _behavior = new ParallelSequenceNode(new IBehaviorNode[]
            {
                new ExecuteBehaviorsNode(sceneData.Characters),

                new SequenceNode(new IBehaviorNode[]
                {
                    new TickNode(dateTime = new DateTime.DateTime(
                        new Date(12, 1, 2022), 
                        new Time(0, 8, 10))
                    ),
                    new RenderNode<IDateTime, IDateView>(dateTime, ui.Date),
                    new RenderNode<IDateTime, ITimeView>(dateTime, ui.Time),
                    new WaitNode(100),
                    new SequenceNode(new IBehaviorNode[]
                    {
                        new CompareDayNode(dateTime, 1),
                        new CompareTimeNode(dateTime, 8, 0),
                        new PayMonthlySalaryNode(sceneData.Employers)
                    })
                }, false, "Time").Repeat(),
                
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
                }, "UI ").Repeat()
                
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