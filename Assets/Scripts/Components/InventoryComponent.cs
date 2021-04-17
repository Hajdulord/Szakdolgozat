using UnityEngine;
using HMF.Thesis.Items;
using HMF.Thesis.Logic;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Components
{
    public class InventoryComponent : MonoBehaviour, IInventoryComponent
    {
        [Header("Serialized Fields")]
        [SerializeField] private WeaponData _mainWeaponData = null!;
        [SerializeField] private int isUseSize = 0;
        private IInventory _inventory;
        public IInventory Inventory => _inventory;

        private void Awake() 
        {
            var mainWeapon = new Weapon(_mainWeaponData);
            _inventory = new InventoryLogic(isUseSize, mainWeapon);
        }
    }
}
