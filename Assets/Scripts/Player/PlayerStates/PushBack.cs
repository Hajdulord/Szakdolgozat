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

        public PushBack(IMove move, Rigidbody2D rigidbody, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _rigidbody = rigidbody;
            _playerStateMachine = playerStateMachine;
        }

        public void OnEnter()
        {
            Debug.Log("PushBack");
            _move.PushBack(_playerStateMachine.PushBackDir);
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
            if (_rigidbody.position.x >= _move.PushBackDistance.x && _rigidbody.position.y >= _move.PushBackDistance.y)
            {
                _playerStateMachine.PushBackDir = Vector2.zero;
            }
        }
    }
}
