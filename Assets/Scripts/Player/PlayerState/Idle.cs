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
        private Animator _animator;
        
        public Idle(Rigidbody2D rigidbody, Animator animator)
        {
            _rigidbody = rigidbody;
            _animator = animator;
        }
        public void OnEnter()
        {
            Debug.Log("Idle");
            _rigidbody.velocity = Vector2.zero;
            _animator.SetFloat("Speed", 0);
            _animator.SetBool("IsFalling", false);

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
