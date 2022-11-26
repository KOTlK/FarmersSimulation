using System;
using BananaParty.BehaviorTree;
using Game.Runtime.Behavior.Session;
using Game.Runtime.Characters.Professions.Warrior;
using Game.Runtime.Characters.Weapons;
using Game.Runtime.Characters.Weapons.Melee;
using Game.Runtime.View.Characters.Warrior;
using UnityEngine;

namespace Game.Tests.PlayModeTests.View
{
    public class WeaponAndHealthWillDisplay : MonoBehaviour
    {
        [SerializeField] private WarriorView _view;
        [SerializeField] private Warrior _model;
        [SerializeField] private WeaponTargets _targets;

        private IBehaviorNode _behavior;
        private void Awake()
        {
            _behavior = new RepeatNode(
                new RenderChainNode<IWarrior, IWarriorView>(new[]
                {
                    new RenderNode<IWarrior, IWarriorView>(_model, _view)
                }));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _model.ApplyDamage(10f);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _model.EquipWeapon(new IronSword());
            }
            _behavior.Execute(1);
        }
    }
}