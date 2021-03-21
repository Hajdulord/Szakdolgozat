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

        private float _time; 

        public Attack(IAttack attack, string[] tagsToTarget, PlayerStateMachine playerStateMachine, IMove move)
        {
            _attack = attack;
            _tagsToTarget = tagsToTarget;
            _playerStateMachine = playerStateMachine;
            _move = move;
            _time = 0;
        }

        public void OnEnter()
        {
            Debug.Log("Attack");
            //Debug.Log(_attack);
            _attack.Attack(_playerStateMachine.CurrentItem, _tagsToTarget);
            _time = Time.time + _playerStateMachine.CurrentItem.attackTime;
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            _move.Move(_playerStateMachine.MoveDirection);
            
            if (_playerStateMachine.IsDashing)
            {
                _move.Dash();
                _playerStateMachine.IsDashing = false;
            }

            if (Time.time >= _time)
            {
                _playerStateMachine.CurrentItem = null;
            }

        }
    }
}
