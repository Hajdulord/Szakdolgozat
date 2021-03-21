using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Player
{
    /// Input Controller that parse the player input.
    /// This class has the methodes for the Input system to call when an input action is performed.
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerStateMachine))]
    public class InputController : MonoBehaviour, IInputController
    {

        [Header("Serializable Fields")]
        [SerializeField] private PlayerStateMachine _stateMachine = null!; ///< The statemachine we get state switching properties from here.

        private float _mainWeaponTime = 0;

        /// Sets the falg to enter the Jump sate.
        /*!
          \param callback is an InputAction.CallbackContext that is used to get data from the InputAction.
        */    
        public void Jump(InputAction.CallbackContext callback)
        {
            if(callback.started)
            {
                _stateMachine.IsJumping = true;
            }
        }

        /// Sets the falg to enter the Move sate.
        /*!
          \param callback is an InputAction.CallbackContext that is used to get data from the InputAction.
        */ 
        public void Move(InputAction.CallbackContext callback)
        {
            if(callback.started)
            {
                _stateMachine.MoveDirection = (int)callback.ReadValue<float>();
            }
            else if(callback.canceled)
            {
                _stateMachine.MoveDirection = 0;
            }
        }

        /// Sets the falg to enter the Attack sate.
        /*!
          \param callback is an InputAction.CallbackContext that is used to get data from the InputAction.
        */ 
        public void NormalMeleeAttack(InputAction.CallbackContext callback)
        {
            if(callback.started && Time.time >= _mainWeaponTime)
            {
                //Debug.Log(_stateMachine.Inventory.MainWeapon);
                _stateMachine.CurrentItem = _stateMachine.Inventory.MainWeapon;
                _mainWeaponTime = Time.time + _stateMachine.Inventory.MainWeapon.attackTime;
            }
        }

        /// Sets the falg to enter the Dash sate.
        /*!
          \param callback is an InputAction.CallbackContext that is used to get data from the InputAction.
        */ 
        public void Dash(InputAction.CallbackContext callback)
        {
            if(callback.started)
            {
                _stateMachine.IsDashing = true;
            }
        }
    }
}
