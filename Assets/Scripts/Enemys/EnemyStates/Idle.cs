using HMF.HMFUtilities.DesignPatterns.StatePattern;
using UnityEngine;

namespace HMF.Thesis.Enemys.EnemyStates
{
    public class Idle : IState
    {
        private Animator _animator;
        
        public Idle(Animator animator)
        {
            _animator = animator;
        }

        public void OnEnter()
        {
            //Debug.Log("Enemy Idle");
            _animator.SetFloat("Speed", 0);
        }

        public void OnExit()
        {
            
        }

        public void Tick()
        {
            
        }
    }
}
