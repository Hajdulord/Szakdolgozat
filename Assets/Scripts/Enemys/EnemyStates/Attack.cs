using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.Enemys.EnemyStates
{
    public class Attack : IState
    {
        private IAttack _attack;

        private string[] _tagsToTarget;

        private BasicEnemyStateMachine _stateMachine;

        private float _time = 0;

        public Attack(IAttack attack, string[] tagsToTarget, BasicEnemyStateMachine stateMachine)
        {
            _attack = attack;
            _tagsToTarget = tagsToTarget;
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Attack");
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            if (Time.time >= _time)
            {
                _attack.Attack(_stateMachine.Weapon, _tagsToTarget);
                _time = Time.time + _stateMachine.weaponData.attackTime;
            }
        }
    }
}
