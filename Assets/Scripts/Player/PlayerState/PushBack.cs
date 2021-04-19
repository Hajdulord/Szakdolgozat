using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Player
{
    public class PushBack : IState
    {
        private IMove _move;
        private Rigidbody2D _rigidbody;
        private PlayerStateMachine _playerStateMachine;
        private Animator _animator;

        public PushBack(IMove move, Animator animator, Rigidbody2D rigidbody, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _rigidbody = rigidbody;
            _playerStateMachine = playerStateMachine;
            _animator = animator;
        }

        public void OnEnter()
        {
            //Debug.Log("PushBack");
            _move.PushBack(_playerStateMachine.PushBackDir);
            _animator.SetBool("IsHurt", true);
        }

        public void OnExit()
        {
            _playerStateMachine.IsJumping = false;
            _animator.SetBool("IsHurt", false);
        }

        public void Tick()
        {
            if (_rigidbody.velocity.x == 0)
            {
                _playerStateMachine.PushBackDir = 0;
                _playerStateMachine.pushBackInmunity = Time.time + 4f;
            }
        }
    }
}
