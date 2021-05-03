using UnityEngine;

namespace HMF.Thesis.Interfaces.ComponentInterfaces
{
    // An Interface for the PickUpableComponent wrapper.
    public interface IPickUpableComponent
    {
        /// A function for Picking up items.
        (ScriptableObject ScriptableData, int Quantity, MyScriptableObjects Scriptable, MyConsumables Consumable) PickUp();
    }
}
