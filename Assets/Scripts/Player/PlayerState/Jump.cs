using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Player.PlayerStates
{
    public class Jump : IState
    {
        private IMove _move;

        private PlayerStateMachine _playerStateMachine;

        private Animator _animator;

        public Jump(IMove move, Animator animator, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _playerStateMachine = playerStateMachine;
            _animator = animator;
        }

        public void OnEnter()
        {
            //_animator.SetBool("IsJumping", true);
            _animator.SetInteger("YDir", 1);
            _move.Jump();
            //Debug.Log("Jump");
        }

        public void OnExit()
        {
            //_playerStateMachine.IsJumping = false;
            //_animator.SetBool("IsJumping", false);
        }

        public void Tick()
        {
            
            _move.Move(_playerStateMachine.MoveDirection);
            
            if (_playerStateMachine.IsDashing)
            {
                if(_move.Dash())
                {
                    _playerStateMachine.DashDust.transform.forward = -_playerStateMachine.transform.forward;
                    _playerStateMachine.DashDust.transform.position = _playerStateMachine.transform.position + -_playerStateMachine.MoveDirection * Vector3.right * 2;
                    //Debug.Log(_playerStateMachine.dashDust.gameObject.transform.position + " " + _playerStateMachine.gameObject.transform.position);
                    _playerStateMachine.DashDust.SetActive(true);
                }
                _playerStateMachine.IsDashing = false;
            }
        }
    }
}
