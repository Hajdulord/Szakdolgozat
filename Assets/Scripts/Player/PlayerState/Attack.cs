using HMF.HMFUtilities.DesignPatterns.StatePattern;
using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Player
{
    public class Attack : IState
    {
        private IAttack _attack;

        private string[] _tagsToTarget;

        private PlayerStateMachine _playerStateMachine;

        private IMove _move;

        private Animator _animator;

        //private float _time; 

        public Attack(IAttack attack, Animator animator, string[] tagsToTarget, PlayerStateMachine playerStateMachine, IMove move)
        {
            _attack = attack;
            _tagsToTarget = tagsToTarget;
            _playerStateMachine = playerStateMachine;
            _move = move;
            _animator = animator;
            //_time = 0;
        }

        public void OnEnter()
        {
            Debug.Log($"Attack with {_playerStateMachine.CurrentItem.Name}");
            //Debug.Log(_attack);
            _attack.Attack(_playerStateMachine.CurrentItem, _tagsToTarget);
            //_time = Time.time + _playerStateMachine.CurrentItem.attackTime;
            if(_playerStateMachine.CurrentItem is HMF.Thesis.Items.MagicFocus)
                _animator.SetBool("IsMagic", true);
            else
                _animator.SetBool("IsAttacking", true);
        }

        public void OnExit()
        {
            _playerStateMachine.IsJumping = false;
            _animator.SetBool("IsAttacking", false);
            _animator.SetBool("IsMagic", false);
        }

        public void Tick()
        {
            //_move.Move(_playerStateMachine.MoveDirection);

            _playerStateMachine.CurrentItem = null;
            
            //if (_playerStateMachine.IsDashing)
            //{
            //    _move.Dash();
            //    _playerStateMachine.IsDashing = false;
            //}

            //if (Time.time >= _time)
            //{
                //_playerStateMachine.CurrentItem = null;
            //}

        }
    }
}