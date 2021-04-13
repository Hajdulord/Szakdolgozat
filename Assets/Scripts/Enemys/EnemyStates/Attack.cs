using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Enemys.EnemyStates
{
    public class Attack : IState
    {
        private IAttack _attack;

        private string[] _tagsToTarget;

        private IEnemyStateMachine _stateMachine;

        private float _time = 0;
        private float _timeMagic = 0;
        private Animator _animator;

        public Attack(IAttack attack, string[] tagsToTarget, IEnemyStateMachine stateMachine, Animator animator)
        {
            _attack = attack;
            _tagsToTarget = tagsToTarget;
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Attack");
            _animator.SetFloat("Speed", 0);
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            if (Time.time >= _time)
            {
                _animator.SetBool("IsAttacking", true);

                _attack.Attack(_stateMachine.Weapon, _tagsToTarget);
                _time = Time.time + _stateMachine.WeaponData.attackTime;
            }
            else
            {
                _animator.SetBool("IsAttacking", false);
            }

            if (_stateMachine.MagicFocusData != null && Time.time >= _timeMagic)
            {
                _animator.SetBool("IsMagic", true);

                _attack.Attack(_stateMachine.MagicFocus, _tagsToTarget);
                _timeMagic = Time.time + _stateMachine.WeaponData.attackTime;
            }
            else
            {
                _animator.SetBool("IsMagic", false);
            }
        }
    }
}
