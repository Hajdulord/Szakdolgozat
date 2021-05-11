using HMF.HMFUtilities.DesignPatterns.StatePattern;
using UnityEngine;

namespace HMF.Thesis.Enemys.EnemyStates
{
    /// Idle state for the enmys.
    public class Idle : IState
    {
        private Animator _animator; ///< The animator for playing animations.
        
        /// Constructor.
        /*!
          \param animator is the animator.
        */
        public Idle(Animator animator)
        {
            _animator = animator;
        }

        /// Sets the animation to idle.
        public void OnEnter()
        {
            //Debug.Log("Enemy Idle");
            _animator.SetFloat("Speed", 0);
        }

        public void OnExit(){ }

        public void Tick(){ }
    }
}
