using UnityEngine;
using UnityEngine.InputSystem;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Misc;

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
        [SerializeField] private GameObject _pauseMenu = null!;

        private Rigidbody2D _rigidbody = null;

        private float _mainWeaponTime = 0;
        private float _inventoryOneTime = 0;
        private float _inventoryTwoTime = 0;
        private float _inventoryThreeTime = 0;
        private float _inventoryFourTime = 0;

        private void Awake() 
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        /// Sets the falg to enter the Jump sate.
        /*!
          \param callback is an InputAction.CallbackContext that is used to get data from the InputAction.
        */    
        public void Jump(InputAction.CallbackContext callback)
        {
            if(callback.started &&  
                !_stateMachine.IsStunned && 
                _stateMachine.GroundCheck() && 
                !Misc.Pause.gameIsPaused)
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
            if(callback.started && !Misc.Pause.gameIsPaused)
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
            if(callback.started && Time.time >= _mainWeaponTime && !Misc.Pause.gameIsPaused)
            {
                //Debug.Log(_stateMachine.Inventory.MainWeapon);
                _mainWeaponTime = Time.time + _stateMachine.Inventory.MainWeapon.attackTime;
                _stateMachine.CurrentItem = _stateMachine.Inventory.MainWeapon;
            }
        }

        public void InventoryOne(InputAction.CallbackContext callback)
        {
            if(callback.started && 
                Time.time >= _inventoryOneTime && 
                _stateMachine.Inventory.InUse.ContainsKey(0) && 
                !Misc.Pause.gameIsPaused)
            {
                ItemCooldownVisualizer.Instance.StartCooldown(0, (int) _stateMachine.Inventory.InUse[0].attackTime);
                _inventoryOneTime = Time.time + _stateMachine.Inventory.InUse[0].attackTime;
                _stateMachine.CurrentItem = _stateMachine.Inventory.GetItem(0);
                //Debug.Log(_stateMachine.Inventory.InUse[0].Name);

                _stateMachine.inventoryUI.UpdateDisplay();
            }
        }

        public void InventoryTwo(InputAction.CallbackContext callback)
        {
            if(callback.started && 
                Time.time >= _inventoryTwoTime && 
                _stateMachine.Inventory.InUse.ContainsKey(1) && 
                !Misc.Pause.gameIsPaused)
            {
                ItemCooldownVisualizer.Instance.StartCooldown(1, (int) _stateMachine.Inventory.InUse[1].attackTime);
                //Debug.Log(_stateMachine.Inventory.MainWeapon);
                _inventoryTwoTime = Time.time + _stateMachine.Inventory.InUse[1].attackTime;
                _stateMachine.CurrentItem = _stateMachine.Inventory.GetItem(1);
                _stateMachine.inventoryUI.UpdateDisplay();
            }
        }

        public void InventoryThree(InputAction.CallbackContext callback)
        {
            if(callback.started && 
                Time.time >= _inventoryThreeTime && 
                _stateMachine.Inventory.InUse.ContainsKey(2) && 
                !Misc.Pause.gameIsPaused)
            {
                ItemCooldownVisualizer.Instance.StartCooldown(2, (int) _stateMachine.Inventory.InUse[2].attackTime);
                //Debug.Log(_stateMachine.Inventory.MainWeapon);
                _inventoryThreeTime = Time.time + _stateMachine.Inventory.InUse[2].attackTime;
                _stateMachine.CurrentItem = _stateMachine.Inventory.GetItem(2);
                _stateMachine.inventoryUI.UpdateDisplay();
            }
        }

        public void InventoryFour(InputAction.CallbackContext callback)
        {
            if(callback.started && 
                Time.time >= _inventoryFourTime && 
                _stateMachine.Inventory.InUse.ContainsKey(3) && 
                !Misc.Pause.gameIsPaused)
            {
                ItemCooldownVisualizer.Instance.StartCooldown(3, (int) _stateMachine.Inventory.InUse[3].attackTime);
                //Debug.Log(_stateMachine.Inventory.MainWeapon);
                _inventoryThreeTime = Time.time + _stateMachine.Inventory.InUse[3].attackTime;
                _stateMachine.CurrentItem = _stateMachine.Inventory.GetItem(3);
                _stateMachine.inventoryUI.UpdateDisplay();
            }
        }

        /// Sets the falg to enter the Dash sate.
        /*!
          \param callback is an InputAction.CallbackContext that is used to get data from the InputAction.
        */ 
        public void Dash(InputAction.CallbackContext callback)
        {
            if(callback.started && !Misc.Pause.gameIsPaused && !_stateMachine.IsStunned)
            {
                _stateMachine.IsDashing = true;
            }
        }

        public void PauseCall(InputAction.CallbackContext callback)
        {
            if(callback.started)
            {
                //Debug.Log("PauseCall");

                if (Misc.Pause.gameIsPaused)
                {
                    UnPause();
                }
                else
                {
                    Pause();
                }

            }
        }

        public void ResetTimes()
        {
            _mainWeaponTime = 0;
            _inventoryOneTime = 0;
            _inventoryTwoTime = 0;
            _inventoryThreeTime = 0;
            _inventoryFourTime = 0;
        }

        public void Pause()
        {
            //Debug.Log("Pause");

            Misc.Pause.PauseGame();
            //GetComponent<PlayerInput>().enabled = true;
            _pauseMenu.SetActive(true);
        }

        public void UnPause()
        {
            //Debug.Log("UnPause");

            Misc.Pause.Resume();
            //GetComponent<PlayerInput>().enabled = true;
            _pauseMenu.SetActive(false);
        }
    }
}
