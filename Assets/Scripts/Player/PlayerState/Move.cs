using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Player.PlayerStates
{
    public class Move : IState
    {
        private IMove _move;

        private PlayerStateMachine _playerStateMachine;

        private Animator _animator;

        public Move(IMove move, Animator animator, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _playerStateMachine = playerStateMachine;
            _animator = animator;
        }

        public void OnEnter()
        {
            //Debug.Log("Move");
            _animator.SetFloat("Speed", Mathf.Abs(_playerStateMachine.MoveDirection));
        }

        public void OnExit()
        {
            _move.Move(_playerStateMachine.MoveDirection);
            _playerStateMachine.IsJumping = false;
        }

        public void Tick()
        {
            _move.Move(_playerStateMachine.MoveDirection);
            
            if (_playerStateMachine.IsDashing)
            {
                if(_move.Dash())
                {
                    _playerStateMachine.dashDust.transform.forward = -_playerStateMachine.transform.forward;
                    _playerStateMachine.dashDust.transform.position = _playerStateMachine.transform.position + -_playerStateMachine.MoveDirection * Vector3.right * 2;
                    //Debug.Log(_playerStateMachine.dashDust.gameObject.transform.position + " " + _playerStateMachine.gameObject.transform.position);
                    _playerStateMachine.dashDust.SetActive(true);
                }
                _playerStateMachine.IsDashing = false;
            }
            
        }
    }
}
