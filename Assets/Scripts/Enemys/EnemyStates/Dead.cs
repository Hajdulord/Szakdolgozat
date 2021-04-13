using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;

namespace HMF.Thesis.Enemys
{
    public class Dead : IState
    {
        private IEnemyStateMachine _stateMachine;
        private Animator _animator;

        public Dead(IEnemyStateMachine stateMachine, Animator animator)
        {
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public void OnEnter()
        {
            Debug.Log("Enemy Dead");
            //_stateMachine.ThisGameObject.SetActive(false);
            _animator.SetBool("IsDead", true);
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            
        }
    }
}
