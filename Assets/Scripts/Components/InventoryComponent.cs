using UnityEngine;
using HMF.Thesis.Items;
using HMF.Thesis.Logic;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Components
{
    /// The component wrapper of the inventory logic.
    public class InventoryComponent : MonoBehaviour, IInventoryComponent
    {
        [Header("Serialized Fields")]
        [SerializeField] private WeaponData _mainWeaponData = null!; ///< The data of the main weapon.
        [SerializeField] private int isUseSize = 0; ///< The size of the inUse inventory.
        private IInventory _inventory; ///< The data of the inventory logic.

        /// Getter of the inventory logic.
        public IInventory Inventory => _inventory;

        private void Awake() 
        {
            var mainWeapon = new Weapon(_mainWeaponData);
            _inventory = new InventoryLogic(isUseSize, mainWeapon);
        }
    }
}
