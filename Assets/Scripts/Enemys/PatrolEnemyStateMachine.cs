using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using System;
using HMF.Thesis.Enemys.EnemyStates;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Items;
using HMF.Thesis.Music;

namespace HMF.Thesis.Enemys
{
    public class PatrolEnemyStateMachine : MonoBehaviour, IEnemyStateMachine
    {
        [Header("Serialized Private Fields")]
        [SerializeField] private List<string> _tagsToTarget = new List<string>();
        [SerializeField] private MagicFocusData _magicFocusData = null;
        [SerializeField] private WeaponData _weaponData = null!;
        [SerializeField] private GameObject _swordPoint = null!;
        [SerializeField] private AudioSource _audioSource = null;
        [SerializeField] private AudioSource _audioSourceAttack = null;
        [SerializeField] private AudioSource _audioSourceAttack2 = null;
        //[SerializeField] private MusicHandler _musicHandler = null;
        [SerializeField] private InRange _inRange = null!;
        [SerializeField] private LayerMask _layersToTarget;


        [Header("Serialized Public Fields")]
        [SerializeField] public GameObject start = null!;
        [SerializeField] public GameObject end = null!;
        
        private StateMachine _stateMachine;
        private IMove _move;
        private IAttack _attack;
        private ICharacter _character;
        private Animator _animator;

        public GameObject Target {get; set;} = null;
        public IItem Weapon {get; private set;}
        public IItem MagicFocus {get; private set;}
        public GameObject SwordPoint {get => _swordPoint; set => _swordPoint = value;}
        public WeaponData WeaponData => _weaponData;
        public MagicFocusData MagicFocusData => _magicFocusData;
        public GameObject ThisGameObject => gameObject;

        public AudioSource AudioSource { get => _audioSource;}
        public AudioSource AudioSourceAttack { get => _audioSourceAttack;}
        public AudioSource AudioSourceAttack2 { get => _audioSourceAttack2;}
        public LayerMask LayersToTarget { get => _layersToTarget; }

        //public MusicHandler MusicHandler { get => _musicHandler;}

        private void Awake()
        {
            _stateMachine = new StateMachine();

            _move = GetComponent<IMoveComponent>().Move;
            _attack = GetComponent<IAttackComponent>().Attack;
            _character = GetComponent<ICharacterComponent>().Character;
            _animator = GetComponent<Animator>();
            
            Weapon = new Weapon(_weaponData);
            if (_magicFocusData != null)
            {
                MagicFocus = new MagicFocus(_magicFocusData);   
            }

            var patrol = new Patrol(_move, this, _animator);
            var moveTo = new MoveTo(_move, this, _animator);
            var attack = new Attack(_attack, _tagsToTarget.ToArray(), this, _animator);
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
            Func<bool> reachedTarget() => () => Target != null && _inRange.inRange;
            Func<bool> targetOutOfReach() => () => Target != null && !_inRange.inRange;
            Func<bool> isDead() => () => _character.Health <= 0;
            //Func<bool> isAlive() => () => _character.Health > 0;

            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
            
            _stateMachine.SetState(patrol);
        }

        private void Update() => _stateMachine.Tick();

        public void Step()
        {
            //_audioSource.clip = _musicHandler.enemyStep;
            _audioSource.clip = MusicHandler.Instance.enemyStep;
            _audioSource.Play();
        }
        
        private void OnDisable() 
        {
            if (_character.Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
