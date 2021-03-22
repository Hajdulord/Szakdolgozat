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
        private float _inventoryOneTime = 0;
        private float _inventoryTwoTime = 0;
        private float _inventoryThreeTime = 0;
        private float _inventoryFourTime = 0;

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

        public void InventoryOne(InputAction.CallbackContext callback)
        {
            if(callback.started && Time.time >= _inventoryOneTime && _stateMachine.Inventory.InUse.ContainsKey(0))
            {
                _stateMachine.CurrentItem = _stateMachine.Inventory.InUse[0];
                //Debug.Log(_stateMachine.Inventory.InUse[0].Name);
                _inventoryOneTime = Time.time + _stateMachine.Inventory.InUse[0].attackTime;
            }
        }

        public void InventoryTwo(InputAction.CallbackContext callback)
        {
            if(callback.started && Time.time >= _inventoryTwoTime && _stateMachine.Inventory.InUse.ContainsKey(1))
            {
                //Debug.Log(_stateMachine.Inventory.MainWeapon);
                _stateMachine.CurrentItem = _stateMachine.Inventory.InUse[1];
                _inventoryTwoTime = Time.time + _stateMachine.Inventory.InUse[1].attackTime;
            }
        }

        public void InventoryThree(InputAction.CallbackContext callback)
        {
            if(callback.started && Time.time >= _inventoryThreeTime && _stateMachine.Inventory.InUse.ContainsKey(2))
            {
                //Debug.Log(_stateMachine.Inventory.MainWeapon);
                _stateMachine.CurrentItem = _stateMachine.Inventory.InUse[2];
                _inventoryThreeTime = Time.time + _stateMachine.Inventory.InUse[2].attackTime;
            }
        }

        public void InventoryFour(InputAction.CallbackContext callback)
        {
            if(callback.started && Time.time >= _inventoryFourTime && _stateMachine.Inventory.InUse.ContainsKey(3))
            {
                //Debug.Log(_stateMachine.Inventory.MainWeapon);
                _stateMachine.CurrentItem = _stateMachine.Inventory.InUse[3];
                _inventoryThreeTime = Time.time + _stateMachine.Inventory.InUse[3].attackTime;
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
