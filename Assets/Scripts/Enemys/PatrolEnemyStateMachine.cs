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
    /// The statemachine and the barain of a patrolling enemy.
    public class PatrolEnemyStateMachine : MonoBehaviour, IEnemyStateMachine
    {
        [Header("Serialized Private Fields")]
        [SerializeField] private List<string> _tagsToTarget = new List<string>(); ///< List of strings that with the tags to target.
        [SerializeField] private MagicFocusData _magicFocusData = null; ///< The data of the magicFocus.
        [SerializeField] private WeaponData _weaponData = null!; ///< The data of main weapon.
        [SerializeField] private GameObject _swordPoint = null!; ///< The gameObject for the swordPoint.
        [SerializeField] private AudioSource _audioSource = null; ///< The audio source for movement sounds.
        [SerializeField] private AudioSource _audioSourceAttack = null; ///< The audio source for sword clases.
        [SerializeField] private AudioSource _audioSourceAttack2 = null; ///< The audio source for screams.
        [SerializeField] private InRange _inRange = null!; ///< Detects if a target is in range.
        [SerializeField] private LayerMask _layersToTarget; ///< The layermask that confines the search for enemys.


        [Header("Serialized Public Fields")]
        [SerializeField] public GameObject start = null!; ///< The gameObject for the start of patrol.
        [SerializeField] public GameObject end = null!; ///< The gameObject for the end of patrol.
        
        private StateMachine _stateMachine; ///< The statemachine.
        private IMove _move; ///< The movement logic.
        private IAttack _attack; ///< The attack logic.
        private ICharacter _character; ///< The character logic.
        private Animator _animator; ///< The animator, for playing animations.

        /// The current target to attack.
        public GameObject Target {get; set;} = null;

        /// The actual main weapon.
        public IItem Weapon {get; private set;}

        /// The actual magicFocus.
        public IItem MagicFocus {get; private set;}

        /// Property for swordPoint.
        public GameObject SwordPoint {get => _swordPoint; set => _swordPoint = value;}

        /// Getter for Weapon data.
        public WeaponData WeaponData => _weaponData;

        /// Getter for magicFocus data.
        public MagicFocusData MagicFocusData => _magicFocusData;

        /// Getter for the gameObject of this script.
        public GameObject ThisGameObject => gameObject;

        /// Getter for Main audio source.
        public AudioSource AudioSource { get => _audioSource;}

        /// Getter for the audio source used for sword clases.
        public AudioSource AudioSourceAttack { get => _audioSourceAttack;}

        /// Getter for the audio source used for screams.
        public AudioSource AudioSourceAttack2 { get => _audioSourceAttack2;}

        /// Getter for tagsToIgnore layermask.
        public LayerMask LayersToTarget { get => _layersToTarget; }

        /// Setup
        private void Awake()
        {
            _stateMachine = new StateMachine();

            // Gets the logics
            _move = GetComponent<IMoveComponent>().Move;
            _attack = GetComponent<IAttackComponent>().Attack;
            _character = GetComponent<ICharacterComponent>().Character;
            _animator = GetComponent<Animator>();
            
            // Weapon setup
            Weapon = new Weapon(_weaponData);
            if (_magicFocusData != null)
            {
                MagicFocus = new MagicFocus(_magicFocusData);   
            }

            // state init
            var patrol = new Patrol(_move, this, _animator);
            var moveTo = new MoveTo(_move, this, _animator);
            var attack = new Attack(_attack, _tagsToTarget.ToArray(), this, _animator);
            var dead = new Dead(this, _animator);

            // transition setup
            At(patrol, moveTo, targetFound());
            At(moveTo, patrol, targetLost());

            At(patrol, attack, reachedTarget());
            At(moveTo, attack, reachedTarget());
            At(attack, patrol, targetLost());
            At(attack, moveTo, targetOutOfReach());
            
            _stateMachine.AddAnyTransition(dead, isDead());

            // transition conditions
            Func<bool> targetFound() => () => Target != null;
            Func<bool> targetLost() => () => Target == null;
            Func<bool> reachedTarget() => () => Target != null && _inRange.inRange;
            Func<bool> targetOutOfReach() => () => Target != null && !_inRange.inRange;
            Func<bool> isDead() => () => _character.Health <= 0;

            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
            
            // sets atartup state
            _stateMachine.SetState(patrol);
        }

        /// Update loop.
        private void Update() => _stateMachine.Tick();

        /// Plays sound when step triggers are fired in animations
        public void Step()
        {
            _audioSource.clip = MusicHandler.Instance.enemyStep;
            _audioSource.Play();
        }
        
        /// If the enemy is disabled.
        private void OnDisable() 
        {
            if (_character.Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
