using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;
using HMF.Thesis.Music;

namespace HMF.Thesis.Player.PlayerStates
{
    /// The death state of the Player.
    public class Death : IState
    {
        private Animator _animator; ///< The Animator of the player.
        private PlayerStateMachine _stateMachine; ///< The statemachine of the player.

        /// Constructor to set the private fields.
        public Death(Animator animator, PlayerStateMachine stateMachine)
        {
            _animator = animator;
            _stateMachine = stateMachine;
        }

        /// Plays death sounds and sets animation variable.
        public void OnEnter()
        {
            _animator.SetBool("IsDead", true);
            _stateMachine.AudioSource.clip = MusicHandler.Instance.Serve(Category.Deaths);
            _stateMachine.AudioSource.Play();
        }

        /// Sets animation variable.
        public void OnExit()
        {
            _animator.SetBool("IsDead", false);
        }

        /// Not needed for this state.
        public void Tick(){}
    }
}
