using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Components
{
    public class PickUpableComponent : MonoBehaviour, IPickUpableComponent
    {
        [SerializeField] private MyScriptableObjects _scriptable;
        [SerializeField] private MyConsumables _consumables;
        [SerializeField] private ScriptableObject _data = null!;
        [SerializeField] private int _quantity = 1;

        public (ScriptableObject ScriptableData, int Quantity, MyScriptableObjects Scriptable, MyConsumables Consumable) PickUp()
        {
            gameObject.SetActive(false);
            return (_data, _quantity, _scriptable, _consumables);
        }
    }
}
