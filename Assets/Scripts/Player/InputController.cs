using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using HMF.Thesis.Interfaces;

//! Needs Unit Tests!
namespace HMF.Thesis.Player
{
    /// Input Controller that parse the player input.
    /// This class has the methodes for the Input system to call when an input action is performed.
    [RequireComponent(typeof(PlayerInput))]
    public class InputController : MonoBehaviour, IInputController
    {

        /// Sets the falg to enter the Jump sate.
        /*!
          \param callback is an InputAction.CallbackContext that is used to get data from the InputAction.
        */    
        public void Jump(InputAction.CallbackContext callback)
        {

        }

        /// Sets the falg to enter the Move sate.
        /*!
          \param callback is an InputAction.CallbackContext that is used to get data from the InputAction.
        */ 
        public void Move(InputAction.CallbackContext callback)
        {

        }

        /// Sets the falg to enter the Attack sate.
        /*!
          \param callback is an InputAction.CallbackContext that is used to get data from the InputAction.
        */ 
        public void NormalMeleeAttack(InputAction.CallbackContext callback)
        {

        }

        /// Sets the falg to enter the Dash sate.
        /*!
          \param callback is an InputAction.CallbackContext that is used to get data from the InputAction.
        */ 
        public void Dash(InputAction.CallbackContext callback)
        {

        }
    }
}
