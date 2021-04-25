using UnityEngine;

namespace HMF.Thesis.Interfaces.ComponentInterfaces
{
    public interface IPickUpableComponent
    {
        (ScriptableObject ScriptableData, int Quantity, MyScriptableObjects Scriptable, MyConsumables Consumable) PickUp();
    }
}
