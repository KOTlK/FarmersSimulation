using System;
using System.Linq;
using Game.Runtime.Factories;
using Game.Runtime.TileMap;
using Game.Runtime.TileMap.Tiles;
using Game.Runtime.TileMap.Tiles.TileTypes;
using Game.Runtime.Behavior;
using Game.Runtime.Behavior.Characters.Professions.Harvester;
using Game.Runtime.Characters;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Environment.Crops.MonoBehaviours;
using Game.Runtime.Environment.Mines;
using Game.Runtime.Input;
using Game.Runtime.Input.View;
using Game.Runtime.Market.Employers;
using Game.Runtime.Rendering;
using Game.Runtime.Rendering.Tiles;
using Game.Runtime.Resources;
using Game.Runtime.Session;
using Game.Runtime.TileMap.Pathfinding;
using Game.Runtime.View.TileGraph;
using UnityEngine;
using Factory = Game.Runtime.TileMap.Tiles.TileTypes.Factory;
using Vector2Int = UnityEngine.Vector2Int;

namespace Game.Runtime.Application
{
    public class Application : MonoBehaviour
    {
        [Header("Rendering")]
        [SerializeField] private RenderLibrary _renderLibrary;
        [SerializeField] private PathView _path;
        [Header("Field")] 
        [SerializeField] private TilesCosts _tilesCosts;
        [SerializeField] private Vector2Int _size = new Vector2Int(100, 100);
        [SerializeField] private Vector2Int _noiseOffset = new Vector2Int(100, 100);
        [SerializeField] private float _noiseScale = 1f;
        [Space]
        [SerializeField] private TextAsset _names;
        [SerializeField] private Transform _debugUIParent;
        [SerializeField] private TreeVisualization _debugGraph;
        [SerializeField] private WorldStorage _storage;
        [SerializeField] private MineStack _mines;
        [SerializeField] private Employer[] _employers;
        [SerializeField] private TreeVisualization _debugSession;
        [SerializeField] private UIRoot _uiRoot = null;
        [SerializeField] private bool _visualizeBehaviors = false;

        private IRenderer _treesRenderer;
        private ISession _session;

        private ITileMap _tileMap;

        private void Start()
        {
            var randomTile = new TileTypeByPerlinNoise(
                new Math.Vectors.Vector2Int(_size.x, _size.y),
                new Math.Vectors.Vector2Int(_noiseOffset.x, _noiseOffset.y),
                _noiseScale);
            _tileMap = new TileMapFactory(
                new Math.Vectors.Vector2Int(_size.x, _size.y),
                randomTile,
                _tilesCosts).Create();

            

            _tileMap.Replace(new Math.Vectors.Vector2Int(5, 3),
                           new Chest(new Math.Vectors.Vector2Int(5, 3), 
                                     new ResourceStorage(100)));
            
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
                var factory = new Factory(
                    new Math.Vectors.Vector2Int(0, 0),
                    new ResourceStorage(1000),
                    new ResourceStorage(1000),
                    new Blueprint(
                        new Blueprint.ResourceStack[]
                        {
                            new(Resource.Wheat, 10)
                        },
                        new Blueprint.ResourceStack[]
                        {
                            new(Resource.Bread, 1)
                        })
                );
                
                _tileMap.Replace(new Math.Vectors.Vector2Int(0, 0), factory);
                _tileMap.Replace(new Math.Vectors.Vector2Int(1, 0), new Empty(new Math.Vectors.Vector2Int(1, 0)));
                _tileMap.Replace(new Math.Vectors.Vector2Int(2, 0), new Empty(new Math.Vectors.Vector2Int(2, 0)));
                _tileMap.Replace(new Math.Vectors.Vector2Int(0, 1), new Empty(new Math.Vectors.Vector2Int(0, 1)));
                _tileMap.Replace(new Math.Vectors.Vector2Int(1, 1), new Empty(new Math.Vectors.Vector2Int(1, 1)));
                _tileMap.Replace(new Math.Vectors.Vector2Int(2, 1), new Empty(new Math.Vectors.Vector2Int(2, 1)));
                _tileMap.Replace(new Math.Vectors.Vector2Int(0, 2), new Empty(new Math.Vectors.Vector2Int(0, 2)));
                _tileMap.Replace(new Math.Vectors.Vector2Int(1, 2), new Empty(new Math.Vectors.Vector2Int(1, 2)));
                _tileMap.Replace(new Math.Vectors.Vector2Int(2, 2), new Empty(new Math.Vectors.Vector2Int(2, 2)));
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse1))
            {
                var worldPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
                var position =
                    new Math.Vectors.Vector2Int(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y));
                _tileMap.Replace(position, new Empty(position));
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
            {
                var worldPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
                var position =
                    new Math.Vectors.Vector2Int(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y));

                var path = _tileMap.FindPath(new Math.Vectors.Vector2Int(10, 0), position);
                path.Visualize(_path);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
            {
                _tileMap.Visualize(_path);
            }
        }

        private long _tick = 0;
        private long _time;
        private void FixedUpdate()
        {
            _time = (long) (Time.realtimeSinceStartupAsDouble * 1000);

            if (_time / 1000 > _tick)
            {
                _tick++;
                _tileMap.Execute(_tick);
                _tileMap.Visualize(_renderLibrary.TileMapRenderer);
                //_tileMap.Visualize(_path);
            }
            

            

            /*_session.Execute(_tick);
            _session.Visualize(_debugSession);
            _debugSession.Visualize();

            if (_visualizeBehaviors)
                _treesRenderer.Render();*/
            
        }
    }
}