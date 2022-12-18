using System;
using System.Linq;
using BananaParty.BehaviorTree;
using Game.Runtime.Factories;
using Game.Runtime.TileMap;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.TileMap.Tiles.TileTypes;
using Game.Runtime.Behavior;
using Game.Runtime.Behavior.Characters;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Behavior.Characters.Professions.Harvester;
using Game.Runtime.Characters;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Environment.Mines;
using Game.Runtime.Input;
using Game.Runtime.Input.Tiles;
using Game.Runtime.Input.View;
using Game.Runtime.Market.Employers;
using Game.Runtime.Random;
using Game.Runtime.Rendering;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;
using Game.Runtime.Session;
using Game.Runtime.TileMap.Pathfinding;
using Game.Runtime.View.TileGraph;
using TMPro;
using UnityEngine;
using Vector2Int = Game.Runtime.Math.Vectors.Vector2Int;

namespace Game.Runtime.Application
{
    public class Application : MonoBehaviour
    {
        [Header("Rendering")]
        [SerializeField] private RenderLibrary _renderLibrary;
        [SerializeField] private PathView _path;
        [Header("Field")] 
        [SerializeField] private TilesCosts _tilesCosts;
        [SerializeField] private UnityEngine.Vector2Int _size = new (100, 100);
        [SerializeField] private UnityEngine.Vector2Int _noiseOffset = new (100, 100);
        [SerializeField] private float _noiseScale = 1f;
        [Space]
        [SerializeField] private TextAsset _names;
        [SerializeField] private Transform _debugUIParent;
        [SerializeField] private TreeVisualization _debugGraph;
        [SerializeField] private WorldStorage _storage;
        [SerializeField] private Employer[] _employers;
        [SerializeField] private TreeVisualization _debugSession;
        [SerializeField] private UIRoot _uiRoot = null;
        [SerializeField] private bool _visualizeBehaviors = false;
        [SerializeField] private TMP_Text _debugText;

        private IRenderer _treesRenderer;
        private ISession _session;

        private ITileMap _tileMap;
        private ITileBuilder _builder;

        private void Start()
        {
            UnityEngine.Application.targetFrameRate = _fps;
            _tilesCosts.Init();
            
            _tileMap = new TileMapFactory(
                new Vector2Int(_size.x, _size.y),
                new TileTypeByPerlinNoise(
                    new Vector2Int(_size.x, _size.y),
                    new Vector2Int(_noiseOffset.x, _noiseOffset.y),
                    _noiseScale),
                _tilesCosts).Create();
            _builder = new TileBuilder(_tileMap);

            IChest chest;
            _builder.Build(chest = new Chest(_tileMap[new Vector2Int(5, 3)],
                                             new ResourceStorage(int.MaxValue)));
            
            _character = new Character(new RandomName(_names.text), new RandomAge(18, 30), new Vector2Int(5, 5));
            _character.Visualize(_renderLibrary.CharacterRenderer);

            _testBehavior = new HarvesterBehavior(
                _character, 
                new ResourceStack<CollectableResource>(_tileMap.GetTiles<Wheat>()), 
                chest,
                _tileMap);


            /*var plants = FindObjectsOfType<Plant>();
            var characters = FindObjectsOfType<Character>();
            var inputs = characters.Select(character => character.GetComponent<IClickInput<ICharacter>>());
            var storageInput = new IClickInput<IWorldStorage>[1]
            {
                _storage.GetComponent<IClickInput<IWorldStorage>>()
            };
            
            var sceneData = new SceneData
            {
                Employers = _employers,
                Characters = characters,
                CharacterInputs = new ClickQueue<ICharacter>(inputs.ToArray()),
                Names = _names,
                Plants = new ResourceStack<IPlant>(plants),
                Mines = _mines,
                Storage = _storage,
                StorageInputs = new ClickQueue<IWorldStorage>(storageInput)
            };
            
            //Debug render for behavior trees
            var renderers = new DebugTreeRenderer[sceneData.Characters.Length];
            var position = Vector2.zero;

            for (var i = 0; i < sceneData.Characters.Length; i++)
            {
                var spawned = Instantiate(_debugGraph, _debugUIParent);
                spawned.transform.position = position;
                position += new Vector2(300, 0);
                
                renderers[i] = new DebugTreeRenderer(
                    sceneData.Characters[i], 
                    spawned
                );
            }

            _treesRenderer = new RenderChain(renderers);

            _session = new Session.Session(
                _uiRoot,
                sceneData);*/
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                _builder.Build(new FactoryBlueprint(_tileMap[new Vector2Int(0, 0)],
                                   new Blueprint(
                                       new Blueprint.ResourceStack[]
                                       {
                                           new(Resource.Wheat, 10)
                                       },
                                       new Blueprint.ResourceStack[]
                                       {
                                           new(Resource.Bread, 1)
                                       }),
                                   _tileMap));
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse1))
            {
                var worldPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
                var position =
                    new Vector2Int((int)worldPosition.x, (int)worldPosition.y);
                _builder.Build(new Empty(position));
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
            {
                var worldPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
                var position =
                    new Vector2Int((int)worldPosition.x, (int)worldPosition.y);

                _debugText.text = $"WorldPos - {worldPosition}, TotalPos - {position}";

            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
            {
                _tileMap.Visualize(_path);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _character.Move(new Vector2Int(-1, 0));
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
            {
                _character.Move(new Vector2Int(1, 0));
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
            {
                _character.Move(new Vector2Int(0, 1));
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
            {
                _character.Move(new Vector2Int(0, -1));
            }
        }

        private ICharacter _character;

        private IBehaviorNode _testBehavior;
        [SerializeField] private int _fps = 60;
        
        private void FixedUpdate()
        {
            var frame = Time.frameCount;

            _tileMap.Execute(frame);
            _testBehavior.Execute(frame);

            _tileMap.Visualize(_renderLibrary.TileMapRenderer);
            
            if (_character == null)
                return;
            _character.Visualize(_renderLibrary.CharacterRenderer);
            _testBehavior.WriteToGraph(_debugGraph);
            _debugGraph.Visualize();

            /*_session.Execute(_tick);
            _session.Visualize(_debugSession);
            _debugSession.Visualize();

            if (_visualizeBehaviors)
                _treesRenderer.Render();*/

        }
    }
}