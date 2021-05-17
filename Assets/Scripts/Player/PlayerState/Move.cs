using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Player.PlayerStates
{
    /// The move state of the Player.
    public class Move : IState
    {
        private IMove _move; ///< The move logic of the player.

        private PlayerStateMachine _playerStateMachine; ///< The statemachine of the player.

        private Animator _animator;  ///< The Animator of the player.

        /// Constructor to set the private fields.
        public Move(IMove move, Animator animator, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _playerStateMachine = playerStateMachine;
            _animator = animator;
        }

        /// Sets animation variable.
        public void OnEnter()
        {
            _animator.SetFloat("Speed", Mathf.Abs(_playerStateMachine.MoveDirection));
        }

        /// Makes a last move and sets state variables.
        public void OnExit()
        {
            _move.Move(_playerStateMachine.MoveDirection);
            _playerStateMachine.IsJumping = false;
            _playerStateMachine.IsDashing = false;
        }

        /// Enables the player to move and dash.
        public void Tick()
        {
            _move.Move(_playerStateMachine.MoveDirection);
            
            if (_playerStateMachine.IsDashing)
            {
                if(_move.Dash())
                {
                    _playerStateMachine.DashDust.transform.forward = -_playerStateMachine.transform.forward;
                    _playerStateMachine.DashDust.transform.position = _playerStateMachine.transform.position + -_playerStateMachine.MoveDirection * Vector3.right * 2;
                    _playerStateMachine.DashDust.SetActive(true);
                }
                _playerStateMachine.IsDashing = false;
            }
            
        }
    }
}
