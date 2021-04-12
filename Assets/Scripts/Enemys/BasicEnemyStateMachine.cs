using System.Collections;
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
    public class BasicEnemyStateMachine : MonoBehaviour
    {
        [Header("Serialized Private Fields")]
        [SerializeField] private List<string> _tagsToIgnore = new List<string>();

        [Header("Serialized Public Fields")]
        [SerializeField] public WeaponData weaponData = null!;

        private StateMachine _stateMachine;
        private IMove _move;
        private IAttack _attack;
        private ICharacter _character;

        public GameObject Target {get; internal set;} = null;
        public IItem Weapon {get; private set;}

        private void Awake()
        {
            _stateMachine = new StateMachine();

            Weapon = new Weapon(weaponData);

            _move = GetComponent<IMoveComponent>().Move;
            _attack = GetComponent<IAttackComponent>().Attack;
            _character = GetComponent<ICharacterComponent>().Character;
            
            var idle = new Idle();
            var moveTo = new MoveTo(_move, this);
            var attack = new Attack(_attack, _tagsToIgnore.ToArray(), this);
            var dead = new Dead(this);

            At(idle, moveTo, targetFound());
            At(moveTo, idle, targetLost());

            At(idle, attack, reachedTarget());
            At(moveTo, attack, reachedTarget());
            At(attack, idle, targetLost());
            At(attack, moveTo, targetOutOfReach());
            
            _stateMachine.AddAnyTransition(dead, isDead());

            Func<bool> targetFound() => () => Target != null;
            Func<bool> targetLost() => () => Target == null;
            Func<bool> reachedTarget() => () => Target != null && Vector2.Distance(transform.position, Target.transform.position) <= weaponData.attackRange - 0.05f;
            Func<bool> targetOutOfReach() => () => Target != null && Vector2.Distance(transform.position, Target.transform.position) > weaponData.attackRange - 0.05f;
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
    }
}
