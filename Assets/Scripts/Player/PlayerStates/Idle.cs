using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;

//! Needs Tests!
//! Needs Comments!
namespace HMF.Thesis.Player.PlayerStates
{
    public class Idle : IState
    {
        private Rigidbody2D _rigidbody;
        public Idle(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }
        public void OnEnter()
        {
            Debug.Log("Idle");
            _rigidbody.velocity = Vector2.zero;
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            //Debug.Log("Idle");
        }
    }
}
