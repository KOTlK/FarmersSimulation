using System;
using System.Collections.Generic;
using System.Linq;
using Game.Runtime.Behavior;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Behavior.Characters.Professions.Farmer;
using Game.Runtime.Characters;
using Game.Runtime.Characters.Professions.Farmer;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Environment.Crops.MonoBehaviours;
using Game.Runtime.Input;
using Game.Runtime.Input.Characters;
using Game.Runtime.Random;
using Game.Runtime.Rendering;
using Game.Runtime.Resources;
using Game.Runtime.View.Characters;
using UnityEngine;

namespace Game.Runtime.Application
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private TextAsset _names;
        [SerializeField] private Transform _debugUIParent;
        [SerializeField] private TreeVisualization _debugGraph;
        [SerializeField] private WorldStorage _storage;
        [SerializeField] private CharacterView _characterView;

        [SerializeField] private bool _visualizeBehaviors = false;

        private IBehavior[] _behaviors;
        private IGrownPlants _grownPlants;

        private IRenderer _treesRenderer;
        private IClickInputs<ICharacter> _characterInputs;

        private readonly Dictionary<ICharacter, IBehavior> _characterBehaviors = new();

        private void Start()
        {
            var plants = FindObjectsOfType<Plant>();
            var characters = FindObjectsOfType<Character>();
            var inputs = characters.Select(character => character.GetComponent<IClickInput<ICharacter>>());
            
            var randomName = new RandomName(_names.text);
            var randomAge = new RandomAge(18f, 65f);

            foreach (var character in characters)
            {
                character.Initialize(randomName, randomAge);
            }

            _characterInputs = new CharacterInputs(inputs.ToArray());
            _grownPlants = new GrownWheat(plants);
            _behaviors = new IBehavior[characters.Length];

            for (var i = 0; i < _behaviors.Length; i++)
            {
                var character = characters[i];

                _behaviors[i] = character.Profession switch
                {
                    Profession.Civilian => new Civilian(character),
                    Profession.Farmer => new FarmerBehavior((IFarmer)character, _grownPlants, _storage),
                    Profession.Miner => throw new NotImplementedException(),
                    Profession.Warrior => throw new NotImplementedException(),
                    _ => throw new NotImplementedException()
                };

                _characterBehaviors.Add(character, _behaviors[i]);
            }
            
            //Debug render for behavior trees
            var renderers = new DebugTreeRenderer[_behaviors.Length];
            var position = Vector2.zero;

            for (var i = 0; i < _behaviors.Length; i++)
            {
                var spawned = Instantiate(_debugGraph, _debugUIParent);
                spawned.transform.position = position;
                position += new Vector2(300, 0);
                
                renderers[i] = new DebugTreeRenderer(
                    _behaviors[i], 
                    spawned
                );
            }

            _treesRenderer = new RenderChain(renderers);
        }

        private void FixedUpdate()
        {
            var time = (long) (Time.realtimeSinceStartupAsDouble * 1000);

            foreach (var behavior in _behaviors)
            {
                behavior.ExecuteBehavior(time);
            }

            if (_visualizeBehaviors == false)
                return;
            
            _treesRenderer.Render();
        }

        private ICharacter _clickedCharacter;
        private void Update()
        {
            if (_characterInputs.HasUnreadInput)
            {
                _clickedCharacter = _characterInputs.GetInput();
                _clickedCharacter.Visualize(_characterView);
            }

            if (_clickedCharacter == null) 
                return;
            
            _characterView.DisplayBehavior(_characterBehaviors[_clickedCharacter]);
        }
    }
}