using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Music;

namespace HMF.Thesis.Player
{
    /// The fall state of the Player.
    public class Fall : IState
    {
        private IMove _move; ///< The move logic of the player.

        private PlayerStateMachine _playerStateMachine; ///< The statemachine of the player.

        private Animator _animator;  ///< The Animator of the player.

        /// Constructor to set the private fields.
        public Fall(IMove move, Animator animator, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _playerStateMachine = playerStateMachine;
            _animator = animator;
        }

        /// Starts falling and sets animation variable.
        public void OnEnter()
        {
            _animator.SetInteger("YDir", -1);

            _move.Fall();
        }

        /// Sets state variables, starts playing sounds and sets animation variable.
        public void OnExit()
        {
            _playerStateMachine.IsJumping = false;
            _playerStateMachine.AudioSource.clip = MusicHandler.Instance.jumpLand;
            _playerStateMachine.AudioSource.Play();
            _animator.SetInteger("YDir", 0);
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
