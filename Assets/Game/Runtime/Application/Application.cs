using System;
using Game.Runtime.Behavior;
using Game.Runtime.Behavior.Characters.Professions;
using Game.Runtime.Behavior.Characters.Professions.Farmer;
using Game.Runtime.Characters;
using Game.Runtime.Characters.Professions.Farmer;
using Game.Runtime.Environment.Crops;
using Game.Runtime.Environment.Crops.MonoBehaviours;
using Game.Runtime.Inventory;
using Game.Runtime.Rendering;
using UnityEngine;
using WheatPlant = Game.Runtime.Environment.Crops.WheatPlant;

namespace Game.Runtime.Application
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private Transform _debugUIParent;
        [SerializeField] private TreeVisualization _debugGraph;
        [SerializeField] private Character[] _characters;
        [SerializeField] private Plant<WheatPlant>[] _plants;
        [SerializeField] private WorldStorage _storage;

        private IBehavior[] _behaviors;
        private IGrownPlants _grownPlants;

        private IRenderer _treesRenderer;

        private void Start()
        {
            _grownPlants = new GrownWheat(_plants);
            _behaviors = new IBehavior[_characters.Length];

            for (var i = 0; i < _behaviors.Length; i++)
            {
                var character = _characters[i];

                _behaviors[i] = character.Profession switch
                {
                    Profession.Civilian => new Civilian(character),
                    Profession.Farmer => new FarmerBehavior((IFarmer)character, _grownPlants, _storage),
                    Profession.Miner => throw new NotImplementedException(),
                    Profession.Warrior => throw new NotImplementedException(),
                    _ => throw new NotImplementedException()
                };
            }

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
            
            _treesRenderer.Render();
        }
    }
}