using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Logic;

namespace HMF.Thesis.Components
{   
    /// A wrapper for DamageableCharacter.
    public class DamageableCharacterComponent : MonoBehaviour, IDamageableComponent
    {
        private IDamageable _damageable; ///< The logic behind this class.

        /// Getter for the Damageable logic.
        public IDamageable Damageable => _damageable;

        /// Gets the Character.
        private void Awake() 
        {
            var character = GetComponent<ICharacterComponent>().Character;

            _damageable = new DamageableCharacterLogic(character);
        }
    }
}
