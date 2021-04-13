using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using System;
using HMF.Thesis.Enemys.EnemyStates;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Items;

namespace HMF.Thesis.Enemys
{
    public class PatrolEnemyStateMachine : MonoBehaviour, IEnemyStateMachine
    {
        [Header("Serialized Private Fields")]
        [SerializeField] private List<string> _tagsToIgnore = new List<string>();
        [SerializeField] private MagicFocusData _magicFocusData = null;
        [SerializeField] private WeaponData _weaponData = null!;

        [Header("Serialized Public Fields")]
        [SerializeField] public GameObject start = null!;
        [SerializeField] public GameObject end = null!;

        private StateMachine _stateMachine;
        private IMove _move;
        private IAttack _attack;
        private ICharacter _character;
        private IMagicHandler _magicHandler;
        private Animator _animator;

        public GameObject Target {get; internal set;} = null;
        public IItem Weapon {get; private set;}
        public IItem MagicFocus {get; private set;}
        public WeaponData WeaponData => _weaponData;
        public MagicFocusData MagicFocusData => _magicFocusData;
        public GameObject ThisGameObject => gameObject;

        private void Awake()
        {
            _stateMachine = new StateMachine();

            _move = GetComponent<IMoveComponent>().Move;
            _attack = GetComponent<IAttackComponent>().Attack;
            _character = GetComponent<ICharacterComponent>().Character;
            _magicHandler = GetComponent<IMagicHandlerComponent>()?.MagicHandler;
            _animator = GetComponent<Animator>();
            
            Weapon = new Weapon(_weaponData);
            if (_magicFocusData != null)
            {
                MagicFocus = new MagicFocus(_magicFocusData, _magicHandler);   
            }

            var patrol = new Patrol(_move, this, _animator);
            var moveTo = new MoveTo(_move, this, _animator);
            var attack = new Attack(_attack, _tagsToIgnore.ToArray(), this, _animator);
            var dead = new Dead(this, _animator);

            At(patrol, moveTo, targetFound());
            At(moveTo, patrol, targetLost());

            At(patrol, attack, reachedTarget());
            At(moveTo, attack, reachedTarget());
            At(attack, patrol, targetLost());
            At(attack, moveTo, targetOutOfReach());
            
            _stateMachine.AddAnyTransition(dead, isDead());

            Func<bool> targetFound() => () => Target != null;
            Func<bool> targetLost() => () => Target == null;
            Func<bool> reachedTarget() => () => Target != null && Vector2.Distance(transform.position, Target.transform.position) <= _weaponData.attackRange - 0.05f;
            Func<bool> targetOutOfReach() => () => Target != null && Vector2.Distance(transform.position, Target.transform.position) > _weaponData.attackRange - 0.05f;
            Func<bool> isDead() => () => _character.Health <= 0;
            //Func<bool> isAlive() => () => _character.Health > 0;

            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);

            _stateMachine.SetState(patrol);
        }

        private void Update() => _stateMachine.Tick();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                Target = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                Target = null;
            }
        }
    }
}
