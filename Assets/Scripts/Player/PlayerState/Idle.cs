using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;

namespace HMF.Thesis.Player.PlayerStates
{
    /// The idle state of the Player.
    public class Idle : IState
    {
        private Rigidbody2D _rigidbody; ///< The Rigidbody of the player.
        private Animator _animator; ///< The Animator of the player.
        
        /// Constructor to set the private fields.
        public Idle(Rigidbody2D rigidbody, Animator animator)
        {
            _rigidbody = rigidbody;
            _animator = animator;
        }

        /// Sets valocity to zero and sets animation variables.
        public void OnEnter()
        {
            _rigidbody.velocity = Vector2.zero;
            _animator.SetFloat("Speed", 0);
            _animator.SetInteger("YDir", 0);
        }

        /// Not needed for this state.
        public void OnExit(){}

        /// Not needed for this state.
        public void Tick(){}
    }
}
