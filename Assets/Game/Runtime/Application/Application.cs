using System;
using System.Collections.Generic;
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
        [Header("Input")] 
        [SerializeField] private InputRoot _inputRoot;
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
        [SerializeField] private TreeVisualization _debugGraph;
        [SerializeField] private UIRoot _uiRoot = null;
        [SerializeField] private TMP_Text _debugText;

        private IRenderer _treesRenderer;
        private ISession _session;

        private void Start()
        {
            UnityEngine.Application.targetFrameRate = _fps;
            
            _tilesCosts.Init();

            var config = new Config(_names.text,
                                    new Vector2Int(_size.x, _size.y),
                                    new Vector2Int(_noiseOffset.x, _noiseOffset.y),
                                    _noiseScale,
                                    _tilesCosts);
            _session = new Session.Session(_uiRoot, _renderLibrary, _inputRoot, config);
        }

        private IBehaviorNode _testBehavior;
        [SerializeField] private int _fps = 60;
        
        private void Update()
        {
            var frame = Time.frameCount;

            _session.Execute(frame);

            _session.Visualize(_debugGraph);
            _debugGraph.Visualize();
        }
    }
}