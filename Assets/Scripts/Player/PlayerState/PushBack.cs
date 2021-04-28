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
        private Animator _animator;

        private float _time = 0f;

        private RigidbodyConstraints2D _constrains;

        public PushBack(IMove move, Animator animator, Rigidbody2D rigidbody, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _rigidbody = rigidbody;
            _playerStateMachine = playerStateMachine;
            _animator = animator;
        }

        public void OnEnter()
        {
            //Debug.Log("PushBack");
            _move.PushBack(_playerStateMachine.PushBackDir);

            //_rigidbody.AddForce(Vector2.down, ForceMode2D.Impulse);

            _animator.SetBool("IsHurt", true);
            _time = Time.time + _playerStateMachine.PushBackTime;

            _constrains = _rigidbody.constraints;

            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

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
            //Debug.Log("PushBack exit");
        }

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
                //Debug.Log("a");
            }

            if (!_playerStateMachine.GroundCheck())
            {
                _rigidbody.AddForce(new Vector2(_playerStateMachine.PushBackDir, -1) * 5f, ForceMode2D.Impulse);
                //Debug.Log("b");
            }
        }
    }
}
