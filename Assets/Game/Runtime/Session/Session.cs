using System.Collections.Generic;
using BananaParty.BehaviorTree;
using Game.Runtime.DateTime;
using Game.Runtime.Application;
using Game.Runtime.Behavior;
using Game.Runtime.Behavior.Application;
using Game.Runtime.Behavior.Characters;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Behavior.Characters.Professions.Harvester;
using Game.Runtime.Behavior.Input;
using Game.Runtime.Behavior.Session;
using Game.Runtime.Behavior.Session.View;
using Game.Runtime.Behavior.Time;
using Game.Runtime.Behavior.Viewport;
using Game.Runtime.Characters;
using Game.Runtime.Input;
using Game.Runtime.Input.Characters;
using Game.Runtime.Input.View;
using Game.Runtime.Market;
using Game.Runtime.Market.Employers;
using Game.Runtime.Math.Vectors;
using Game.Runtime.Random;
using Game.Runtime.Rendering.Characters;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;
using Game.Runtime.TileMap;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.TileMap.Tiles.TileTypes;
using Game.Runtime.View.Characters;
using Game.Runtime.View.DateTime;
using Game.Runtime.View.Screens;
using Game.Runtime.View.Storage;

namespace Game.Runtime.Session
{
    public class Session : ISession
    {
        private readonly IBehaviorNode _behavior;
        
        public Session(IUserInterfaceRoot ui, IRenderLibrary renderLibrary, IInputRoot input, IConfig config)
        {
            var behaviors = new List<IBehaviorNode>();
            var spawnedCharacters = new List<ICharacter>();
            var randomName = new RandomName(config.Names);
            var randomAge = new RandomAge(19, 95);

            var tileMap = new TileMapFactory(
                config.TileMapSize,
                new TileTypeByPerlinNoise(
                    config.TileMapSize,
                    config.TileMapNoiseOffset,
                    config.TileMapNoiseScale),
                config.TilesCosts).Create();
            
            var builder = new TileBuilder(tileMap);

            IChest chest;
            builder.Build(chest = new Chest(tileMap[new Vector2Int(5, 3)], new ResourceStorage(int.MaxValue)));

            var chests = new List<IChest>();
            chests.Add(chest);
            
            var employers = new List<IEmployer>(new[]
            {
                new Farm(new Market.Market())
            });
            
            var selectedCharacter = new CharacterSelector();
            IDateTime dateTime;

            _behavior = new SequenceNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new SpawnCharactersNode(10, spawnedCharacters, randomAge, randomName),
                    new InitializeBehaviorsNode(behaviors, spawnedCharacters, new BehaviorFactory(
                                                    new ResourceQueue<CollectableResource>(tileMap.GetTiles<Wheat>()),
                                                    new ResourceQueue<CollectableResource>(tileMap.GetTiles<CopperMine>()),
                                                    chest,
                                                    tileMap)),
                    new SwitchScreenNode(Screen.PauseMenu, ui.Viewport)
                }, false, "Initialization"),

                new ParallelSequenceNode(new IBehaviorNode[]
                {
                    new SelectorNode(new IBehaviorNode[]
                    {
                        new ParallelSequenceNode(new IBehaviorNode[]
                        {
                            new SequenceNode(new IBehaviorNode[]
                            {
                                new WaitButtonClickNode(ui.PauseMenu.Continue),
                                new SwitchScreenNode(Screen.Game, ui.Viewport)
                            }, false, "Pause").Invert(),
                            
                            new SequenceNode(new IBehaviorNode[]
                            {
                                new WaitButtonClickNode(ui.PauseMenu.Exit),
                                new ExitGameNode()
                            })
                        }),
                        
                        
                        new SequenceNode(new IBehaviorNode[]
                        {
                            new SequenceNode(new IBehaviorNode[]
                            {
                                new IsBackButtonPressedNode(input.PlayerInput),
                                new SwitchScreenNode(Screen.PauseMenu, ui.Viewport)
                            }).Invert(),
                            
                            new ExecuteAiBehaviorsNode(behaviors),
                            
                            new TickNode(dateTime = new DateTime.DateTime(
                                             new Date(1, 1, 2000),
                                             new Time(0, 8, 10))
                            ),
                            
                            new ExecuteGameLoop(new IGameLoop[]
                            {
                                tileMap
                            }),
                            
                            new SequenceNode(new IBehaviorNode[]
                            {
                                new RenderNode<ITileMap, ITileMapRenderer>(tileMap, renderLibrary.TileMapRenderer),
                                new RenderChainNode<ICharacter, ICharacterRenderer>(
                                    spawnedCharacters, renderLibrary.CharacterRenderer),
                                new RenderNode<IDateTime, IDateView>(dateTime, ui.Date),
                                new RenderNode<IDateTime, ITimeView>(dateTime, ui.Time),
                            }, false, "Rendering"),
                            
                            new ConstantSequenceNode(new IBehaviorNode[]
                            {
                                new SelectorNode(new IBehaviorNode[]
                                {
                                    new SequenceNode(new IBehaviorNode[]
                                    {
                                        new IsCharacterClickedNode(input.Mouse, spawnedCharacters, selectedCharacter),
                                        new ActivateElementNode(ui.CharacterInfoElement)
                                    }),
                                    
                                    new SequenceNode(new IBehaviorNode[]
                                    {
                                        new IsElementActiveNode(ui.CharacterInfoElement),
                                        new ParallelSequenceNode(new IBehaviorNode[]
                                        {
                                            new WaitButtonClickNode(ui.CharacterInfoElement.CloseButton).Invert(),
                                            new RenderNode<ICharacter, ICharacterView>(
                                                selectedCharacter, ui.CharacterInfoElement.CharacterView),
                                            new WaitCharacterClickNode(selectedCharacter, input.Mouse, spawnedCharacters)
                                        }).RepeatUntilFailure().Invert(),
                                        new DeactivateElementNode(ui.CharacterInfoElement)
                                    })
                                    
                                }),
                                
                                new SelectorNode(new IBehaviorNode[]
                                {
                                    new SequenceNode(new IBehaviorNode[]
                                    {
                                        new IsGameObjectClicked<IChest>(chests, input.Mouse),
                                        new ActivateElementNode(ui.StorageElement)
                                    }),

                                    new SequenceNode(new IBehaviorNode[]
                                    {
                                        new IsElementActiveNode(ui.StorageElement),
                                        new ParallelSequenceNode(new IBehaviorNode[]
                                        {
                                            new WaitButtonClickNode(ui.StorageElement.CloseButton).Invert(),
                                            new RenderNode<IChest, IResourceStorageView>(chest, ui.StorageElement)
                                        }).RepeatUntilFailure().Invert(),
                                        new DeactivateElementNode(ui.StorageElement)
                                    })
                                    
                                })
                                
                            }, BehaviorNodeStatus.Success),

                        }).RepeatUntilFailure()
                    }),

                }).Repeat()
            });

        }

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