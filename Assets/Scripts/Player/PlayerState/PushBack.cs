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

        private float _time = 0f;

        private RigidbodyConstraints2D _constrains;

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
            _time = Time.time + _playerStateMachine.PushBackTime;

            _constrains = _rigidbody.constraints;

            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public void OnExit()
        {
            _playerStateMachine.IsJumping = false;
            _animator.SetBool("IsHurt", false);
            _rigidbody.constraints = _constrains;
            _playerStateMachine.PushBackInmunity = Time.time + 2f;

        }

        public void Tick()
        {
            if (Time.time >= _time || _rigidbody.velocity.x == 0)
            {
                _playerStateMachine.PushBackDir = 0;
            }
        }
    }
}
