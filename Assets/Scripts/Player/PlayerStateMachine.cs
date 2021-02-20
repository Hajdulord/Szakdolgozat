using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.HMFUtilities.DesignPatterns.StatePattern;

namespace HMF.Thesis.Player
{
    /// This class is used to manage the player's state. 
    [RequireComponent(typeof(CharacterController))]
    public class PlayerStateMachine : MonoBehaviour
    {
        [Header("Serialized Fields")]
        [SerializeField] private CharacterController _characterController = null!; ///< The CharacterController is used for moving the player character.
        private StateMachine _stateMachine; ///< The statemachine is used to garantee the consistency of the players state.

        /// Runs before the Start methode, this is used for the setting up the enviornment.
        private void Awake() {
            
            _stateMachine = new StateMachine();
        }
    }
}
