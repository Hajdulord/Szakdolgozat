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

        public Move(IMove move, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _playerStateMachine = playerStateMachine;
        }

        public void OnEnter()
        {
            Debug.Log("Move");
        }

        public void OnExit()
        {
            _move.Move(_playerStateMachine.MoveDirection);
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