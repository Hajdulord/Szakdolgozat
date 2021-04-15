using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Logic;
using UnityEngine;

namespace HMF.Thesis.Components
{
    public class HealableComponent : MonoBehaviour, IHealableComponent
    {
        private IHealable _helable;
        public IHealable Healable => _helable;

        private void Awake() 
        {
            var character = GetComponent<ICharacterComponent>()?.Character;
            _helable = new HealableLogic(character);
        }
    }
}
