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

        public Fall(IMove move, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _playerStateMachine = playerStateMachine;
        }

        public void OnEnter()
        {
            Debug.Log("Fall");
            _move.Fall();
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
