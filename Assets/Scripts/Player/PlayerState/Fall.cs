using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Music;

namespace HMF.Thesis.Player
{
    public class Fall : IState
    {
        private IMove _move;

        private PlayerStateMachine _playerStateMachine;

        private Animator _animator;

        public Fall(IMove move, Animator animator, PlayerStateMachine playerStateMachine)
        {
            _move = move;
            _playerStateMachine = playerStateMachine;
            _animator = animator;
        }

        public void OnEnter()
        {
            //Debug.Log("Fall");
            //_animator.SetBool("IsFalling", true);
            _animator.SetInteger("YDir", -1);

            _move.Fall();
        }

        public void OnExit()
        {
            _playerStateMachine.IsJumping = false;
            //_playerStateMachine.audioSource.clip = _playerStateMachine.musicHandler.jumpLand;
            _playerStateMachine.audioSource.clip = MusicHandler.Instance.jumpLand;
            _playerStateMachine.audioSource.Play();
            _animator.SetInteger("YDir", 0);
            //_animator.SetBool("IsFalling", false);
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
