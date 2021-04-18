using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using System;
using HMF.Thesis.Enemys.EnemyStates;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Music;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Items;

namespace HMF.Thesis.Enemys
{
    public class BasicEnemyStateMachine : MonoBehaviour, IEnemyStateMachine
    {
        [Header("Serialized Private Fields")]
        [SerializeField] private List<string> _tagsToTarget = new List<string>();
        [SerializeField] private WeaponData _weaponData = null!;
        [SerializeField] private MagicFocusData _magicFocusData = null;
        [SerializeField] private GameObject _swordPoint = null!;
        [SerializeField] public AudioSource _audioSource = null;
        [SerializeField] public AudioSource _audioSourceAttack = null;
        [SerializeField] public AudioSource _audioSourceAttack2 = null;
        [SerializeField] public MusicHandler _musicHandler = null;

        private StateMachine _stateMachine;
        private IMove _move;
        private IAttack _attack;
        private IMagicHandler _magicHandler;
        private ICharacter _character;
        private Animator _animator;

        public GameObject Target {get; internal set;} = null;
        public IItem Weapon {get; private set;}
        public IItem MagicFocus {get; private set;} = null;
        public GameObject SwordPoint {get => _swordPoint; set => _swordPoint = value;}
        public WeaponData WeaponData => _weaponData;
        public MagicFocusData MagicFocusData => _magicFocusData;
        public GameObject ThisGameObject => gameObject;

        public AudioSource AudioSource { get => _audioSource;}
        public AudioSource AudioSourceAttack { get => _audioSourceAttack;}
        public AudioSource AudioSourceAttack2 { get => _audioSourceAttack2;}
        public MusicHandler MusicHandler { get => _musicHandler;}

        private void Awake()
        {
            _stateMachine = new StateMachine();

            _move = GetComponent<IMoveComponent>().Move;
            _attack = GetComponent<IAttackComponent>().Attack;
            _magicHandler = GetComponent<IMagicHandlerComponent>()?.MagicHandler;
            _character = GetComponent<ICharacterComponent>().Character;
            _animator = GetComponent<Animator>();
            
            Weapon = new Weapon(_weaponData);
            if (_magicFocusData != null)
            {
                MagicFocus = new MagicFocus(_magicFocusData, _magicHandler);   
            }

            var idle = new Idle(_animator);
            var moveTo = new MoveTo(_move, this, _animator);
            var attack = new Attack(_attack, _tagsToTarget.ToArray(), this, _animator);
            var dead = new Dead(this, _animator);

            At(idle, moveTo, targetFound());
            At(moveTo, idle, targetLost());

            At(idle, attack, reachedTarget());
            At(moveTo, attack, reachedTarget());
            At(attack, idle, targetLost());
            At(attack, moveTo, targetOutOfReach());
            
            _stateMachine.AddAnyTransition(dead, isDead());

            Func<bool> targetFound() => () => Target != null;
            Func<bool> targetLost() => () => Target == null;
            Func<bool> reachedTarget() => () => Target != null && Vector2.Distance(SwordPoint.transform.position, Target.transform.position) <= _weaponData.attackRange - 0.05f;
            Func<bool> targetOutOfReach() => () => Target != null && Vector2.Distance(SwordPoint.transform.position, Target.transform.position) > _weaponData.attackRange - 0.05f;
            Func<bool> isDead() => () => _character.Health <= 0;
            //Func<bool> isAlive() => () => _character.Health > 0;

            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);

            _stateMachine.SetState(idle);
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

        public void Step()
        {
            _audioSource.clip = _musicHandler.enemyStep;
            _audioSource.Play();
        }

    }
}
