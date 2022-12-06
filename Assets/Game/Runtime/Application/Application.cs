using System.Linq;
using Game.Runtime.Behavior;
using Game.Runtime.Behavior.Characters.Professions.Harvester;
using Game.Runtime.Characters;
using Game.Runtime.Characters.Professions;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Environment.Crops.MonoBehaviours;
using Game.Runtime.Environment.Mines;
using Game.Runtime.Input;
using Game.Runtime.Input.View;
using Game.Runtime.Market.Employers;
using Game.Runtime.Rendering;
using Game.Runtime.Resources;
using Game.Runtime.Session;
using UnityEngine;

namespace Game.Runtime.Application
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private TextAsset _names;
        [SerializeField] private Transform _debugUIParent;
        [SerializeField] private TreeVisualization _debugGraph;
        [SerializeField] private WorldStorage _storage;
        [SerializeField] private MineStack _mines;
        [SerializeField] private Factory[] _employers;
        [SerializeField] private TreeVisualization _debugSession;
        [SerializeField] private UIRoot _uiRoot = null;
        [SerializeField] private bool _visualizeBehaviors = false;

        private IRenderer _treesRenderer;
        private ISession _session;

        private void Start()
        {
            var plants = FindObjectsOfType<Plant>();
            var characters = FindObjectsOfType<FriendlyCharacter>();
            var inputs = characters.Select(character => character.GetComponent<IClickInput<IFriendlyCharacter>>());
            var storageInput = new IClickInput<IWorldStorage>[1]
            {
                _storage.GetComponent<IClickInput<IWorldStorage>>()
            };

            var sceneData = new SceneData
            {
                Employers = _employers,
                Characters = characters,
                CharacterInputs = new ClickQueue<IFriendlyCharacter>(inputs.ToArray()),
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
                sceneData);
        }

        private void FixedUpdate()
        {
            var time = (long) (Time.realtimeSinceStartupAsDouble * 1000);

            _session.Execute(time);
            _session.Visualize(_debugSession);
            _debugSession.Visualize();

            if (_visualizeBehaviors)
                _treesRenderer.Render();
            
        }
    }
}