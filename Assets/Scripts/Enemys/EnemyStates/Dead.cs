using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Music;
using System.Collections.Generic;
using System.Linq;
using HMF.Thesis.Misc;

namespace HMF.Thesis.Enemys
{
    /// The state when an enemy is dead.
    public class Dead : IState
    {
        private IEnemyStateMachine _stateMachine; ///< The enemy's statemachine.
        private Animator _animator; ///< The animator, for playing animations.

        /// Constructor.
        /*!
          \param stateMachine is the enemy's satemachine.
          \param animator is the animator.
        */
        public Dead(IEnemyStateMachine stateMachine, Animator animator)
        {
            _stateMachine = stateMachine;
            _animator = animator;
        }

        /// Starts the necessary preparatons for death.
        public void OnEnter()
        {
            Score.Instance.IncreaseKills();

            //Debug.Log("Enemy Dead");

            // dead animation
            _animator.SetBool("IsDead", true);
            
            // plays death sounds
            _stateMachine.AudioSource.clip = MusicHandler.Instance.Serve(Category.Deaths);
            _stateMachine.AudioSource.Play();

            // makes the enemy stay in place and enables the player to move through it
            var colliders = new List<Collider2D>();
            var rb = _stateMachine.ThisGameObject.GetComponent<Rigidbody2D>();
            rb?.GetAttachedColliders(colliders);

            if (colliders.Any())
            {
                foreach (var collider in colliders)
                {
                    collider.attachedRigidbody.gravityScale = 0;
                    collider.enabled = false;
                }
            }
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.simulated = false;
        }

        public void OnExit(){ }

        public void Tick(){ }
    }
}
