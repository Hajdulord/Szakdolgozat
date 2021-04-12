using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using System;

namespace HMF.Thesis.Enemys
{
    public class BasicEnemyStateMachine : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private GameObject _target = null;

        private void Awake()
        {
            _stateMachine = new StateMachine();
            

            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                _target = other.gameObject;
            }
        }

        private void OnCollisionExit2D(Collision2D other) 
        {
            if (other.gameObject.tag == "Player")
            {
                _target = null;
            }
        }
    }
}
