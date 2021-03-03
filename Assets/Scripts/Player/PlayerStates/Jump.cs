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

        public Jump(IMove move, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _playerStateMachine = playerStateMachine;
        }

        public void OnEnter()
        {
            _move.JumpSet();
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            _move.Jump(_playerStateMachine.MoveDirection);
            
            if (_playerStateMachine.IsDashing)
            {
                _move.Dash();
                _playerStateMachine.IsDashing = false;
            }

            if(_playerStateMachine.transform.position.y + 0.05f > _move.JumpMaxHeight)
            {
                _move.ResetY();
            }

        }
    }
}
