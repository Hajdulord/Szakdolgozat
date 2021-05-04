using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Components
{
    /// A component that lets you pick up an item.
    public class PickUpableComponent : MonoBehaviour, IPickUpableComponent
    {
        [SerializeField] private MyScriptableObjects _scriptable; ///< The scriptableObject type of the item to pick up.
        [SerializeField] private MyConsumables _consumables; ///< The consumable type of the item to pick up.
        [SerializeField] private ScriptableObject _data = null!; ///< The data of ScriptableObject to pick up.
        [SerializeField] private int _quantity = 1; ///< The quantity of the item.

        /// It gives the neccessary information to create an item.
        public (ScriptableObject ScriptableData, int Quantity, MyScriptableObjects Scriptable, MyConsumables Consumable) PickUp()
        {
            gameObject.SetActive(false);
            return (_data, _quantity, _scriptable, _consumables);
        }
    }
}
