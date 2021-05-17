using UnityEngine;
using UnityEngine.InputSystem;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Misc;
using HMF.Thesis.Items;
using HMF.Thesis.ScriptableObjects;

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
        [SerializeField] private GameObject _pauseMenu = null!; ///< Reference to the pause menu.
        [SerializeField] private GameObject _saveMenu = null!; ///< Reference to the save menu.

        private Rigidbody2D _rigidbody = null; ///< the rigidbogy of the player.

        private float _mainWeaponTime = 0; ///< Time for the nex possible use of the main weapon.
        private float _inventoryOneTime = 0; ///< Time for the nex possible use of the first item.
        private float _inventoryTwoTime = 0; ///< Time for the nex possible use of the second item.
        private float _inventoryThreeTime = 0; ///< Time for the nex possible use of the third item.
        private float _inventoryFourTime = 0; ///< Time for the nex possible use of the fourth item.

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

        /// Input call for the first inventory slot.
        public void InventoryOne(InputAction.CallbackContext callback)
        {
            if(callback.started && 
                Time.time >= _inventoryOneTime && 
                _stateMachine.Inventory.InUse.ContainsKey(0) && 
                !Misc.Pause.gameIsPaused)
            {
                ItemCooldownVisualizer.Instance.StartCooldown(0, (int) _stateMachine.Inventory.InUse[0].attackTime);
                _inventoryOneTime = Time.time + _stateMachine.Inventory.InUse[0].attackTime;

                if (!_stateMachine.Inventory.InUse.ContainsKey(0))
                {
                    _inventoryOneTime = 0;
                }

                _stateMachine.CurrentItem = _stateMachine.Inventory.GetItem(0);

                _stateMachine.inventoryUI.UpdateDisplay();
            }
        }

        /// Input call for the second inventory slot.
        public void InventoryTwo(InputAction.CallbackContext callback)
        {
            if(callback.started && 
                Time.time >= _inventoryTwoTime && 
                _stateMachine.Inventory.InUse.ContainsKey(1) && 
                !Misc.Pause.gameIsPaused)
            {
                ItemCooldownVisualizer.Instance.StartCooldown(1, (int) _stateMachine.Inventory.InUse[1].attackTime);

                _inventoryTwoTime = Time.time + _stateMachine.Inventory.InUse[1].attackTime;
                _stateMachine.CurrentItem = _stateMachine.Inventory.GetItem(1);

                if (!_stateMachine.Inventory.InUse.ContainsKey(1))
                {
                    _inventoryTwoTime = 0;
                }

                _stateMachine.inventoryUI.UpdateDisplay();
            }
        }

        /// Input call for the third inventory slot.
        public void InventoryThree(InputAction.CallbackContext callback)
        {
            if(callback.started && 
                Time.time >= _inventoryThreeTime && 
                _stateMachine.Inventory.InUse.ContainsKey(2) && 
                !Misc.Pause.gameIsPaused)
            {
                ItemCooldownVisualizer.Instance.StartCooldown(2, (int) _stateMachine.Inventory.InUse[2].attackTime);

                _inventoryThreeTime = Time.time + _stateMachine.Inventory.InUse[2].attackTime;
                _stateMachine.CurrentItem = _stateMachine.Inventory.GetItem(2);

                if (!_stateMachine.Inventory.InUse.ContainsKey(2))
                {
                    _inventoryThreeTime = 0;
                }

                _stateMachine.inventoryUI.UpdateDisplay();
            }
        }

        /// Input call for the fourth inventory slot.
        public void InventoryFour(InputAction.CallbackContext callback)
        {
            if(callback.started && 
                Time.time >= _inventoryFourTime && 
                _stateMachine.Inventory.InUse.ContainsKey(3) && 
                !Misc.Pause.gameIsPaused)
            {
                ItemCooldownVisualizer.Instance.StartCooldown(3, (int) _stateMachine.Inventory.InUse[3].attackTime);

                _inventoryFourTime = Time.time + _stateMachine.Inventory.InUse[3].attackTime;
                _stateMachine.CurrentItem = _stateMachine.Inventory.GetItem(3);

                if (!_stateMachine.Inventory.InUse.ContainsKey(3))
                {
                    _inventoryFourTime = 0;
                }

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

        /// Input call to pause.
        public void PauseCall(InputAction.CallbackContext callback)
        {
            if(callback.started)
            {
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

        /// Picks up an item.
        public void PickUp(InputAction.CallbackContext callback)
        {
            if(callback.started)
            {
                // gets all items in range.
                var colliders = Physics2D.OverlapCircleAll(_rigidbody.position, 2f, _stateMachine.PickUpLayers);

                foreach(var collider in colliders)
                {
                    // checks if the item is PickUpable
                    var pickUp = collider.gameObject.GetComponent<IPickUpableComponent>();

                    if (pickUp != null)
                    {
                        var data = pickUp.PickUp();

                        var item = ParseData(data);

                        // adds the item to inventory.
                        if (item != null)
                        {
                            if (item is Weapon)
                            {
                                _stateMachine.Inventory.MainWeapon = item;
                                _mainWeaponTime = 0;
                            }
                            else if(_stateMachine.Inventory.InventoryShelf.ContainsKey(item.Name))
                            {
                                _stateMachine.Inventory.AddItem(item, data.Quantity);
                            }
                            else if(_stateMachine.Inventory.InUseSize > _stateMachine.Inventory.InUse.Count)
                            {
                                _stateMachine.Inventory.AddItem(item, data.Quantity);
                                _stateMachine.Inventory.SetUse(item);
                            }
                            
                            _stateMachine.inventoryUI.UpdateDisplay();
                        }

                        return;
                    }
                }
            }
        }

        /// Parses data into an item.
        /*!
          \param data holds the actual ScriptableObject, the quantity of it, its type.
          \returns IItem.
        */
        private IItem ParseData((ScriptableObject ScriptableData, int Quantity, MyScriptableObjects Scriptable, MyConsumables Consumable) data)
        {
            switch (data.Scriptable)
            {
                case MyScriptableObjects.WeaponData:
                    return new Weapon(data.ScriptableData as WeaponData);

                case MyScriptableObjects.MagicFocusData:
                    return new MagicFocus(data.ScriptableData as MagicFocusData);

                case MyScriptableObjects.ConsumableData:
                    switch (data.Consumable)
                    {
                        case MyConsumables.HealthPotion:
                            return new HealthPotion(data.ScriptableData as ConsumableData);

                        case MyConsumables.CurePotion:
                            return new CurePotion(data.ScriptableData as ConsumableData);

                        case MyConsumables.None:
                        default:
                            return null;
                    }

                case MyScriptableObjects.None:
                default:
                    return null;
            }
        }

        /// Reseets the cooldowns.
        public void ResetTimes()
        {
            _mainWeaponTime = 0;
            _inventoryOneTime = 0;
            _inventoryTwoTime = 0;
            _inventoryThreeTime = 0;
            _inventoryFourTime = 0;
        }

        /// Pauses the game.
        public void Pause()
        {
            Misc.Pause.PauseGame();

            _pauseMenu.SetActive(true);

            Menu.Menu.flipPausedBool();
        }

        /// Unpauses the game.
        public void UnPause()
        {
            Misc.Pause.Resume();

            _pauseMenu.SetActive(false);
            _saveMenu.SetActive(false);
            
            Menu.Menu.flipPausedBool();
        }
    }
}
