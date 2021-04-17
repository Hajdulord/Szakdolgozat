using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Player
{
    public class Fall : IState
    {
        private IMove _move;

        private PlayerStateMachine _playerStateMachine;

        private Animator _animator;

        public Fall(IMove move, Animator animator, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _playerStateMachine = playerStateMachine;
            _animator = animator;
        }

        public void OnEnter()
        {
            //Debug.Log("Fall");
            _move.Fall();
            _animator.SetBool("IsFalling", true);
        }

        public void OnExit()
        {
            _playerStateMachine.IsJumping = false;
        }

        public void Tick()
        {
            _move.Move(_playerStateMachine.MoveDirection);
            
            if (_playerStateMachine.IsDashing)
            {
                _move.Dash();
                _playerStateMachine.IsDashing = false;
            }
            
        }
    }
}
