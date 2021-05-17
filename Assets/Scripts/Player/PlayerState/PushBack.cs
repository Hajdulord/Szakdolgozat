using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Player
{
    /// The pushback state of the Player.
    public class PushBack : IState
    {
        private IMove _move; ///< The move logic of the player.
        private Rigidbody2D _rigidbody; ///<  The rigidbody of the player.
        private PlayerStateMachine _playerStateMachine; ///< The statemachine of the player.
        private Animator _animator;  ///< The Animator of the player.

        private float _time = 0f; ///< Time of the pushback.

        private RigidbodyConstraints2D _constrains; ///< previous constrains.

        /// Constructor to set the private fields.
        public PushBack(IMove move, Animator animator, Rigidbody2D rigidbody, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _rigidbody = rigidbody;
            _playerStateMachine = playerStateMachine;
            _animator = animator;
        }

        /// Starts a pushBack, save and set constrains and sets animation variable.
        public void OnEnter()
        {
            _move.PushBack(_playerStateMachine.PushBackDir);

            _animator.SetBool("IsHurt", true);

            _time = Time.time + _playerStateMachine.PushBackTime;

            _constrains = _rigidbody.constraints;

            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        /// Reset constrains, sets state variables, sets pushback immunity and sets animation variable.
        public void OnExit()
        {
            _playerStateMachine.IsJumping = false;
            _animator.SetBool("IsHurt", false);
            if (_playerStateMachine.IsStunned)
            {
                _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                _rigidbody.constraints = _constrains;
            }

            _playerStateMachine.PushBackInmunity = Time.time + 2f;
            _playerStateMachine.IsDashing = false;
            _playerStateMachine.CurrentItem = null;
        }

        /// If the player is not grounded pushes it back again.
        public void Tick()
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

            if ((Time.time >= _time || _rigidbody.velocity.x == 0) && _playerStateMachine.GroundCheck())
            {
                _playerStateMachine.PushBackDir = 0;
            }
            else if(Time.time < _time && !_playerStateMachine.GroundCheck())
            {
                _move.PushBack(_playerStateMachine.PushBackDir);
                _rigidbody.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            }

            if (!_playerStateMachine.GroundCheck())
            {
                _rigidbody.AddForce(new Vector2(_playerStateMachine.PushBackDir, -1) * 5f, ForceMode2D.Impulse);
            }
        }
    }
}
