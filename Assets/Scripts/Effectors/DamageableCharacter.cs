using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Effectors
{
    /// A class for objects that are damageable.
    [RequireComponent(typeof(Character))]
    public class DamageableCharacter : MonoBehaviour, IDamageable
    {
        [Header("Serializable Fields")]
        [SerializeField] private ICharacter _character = null!; ///< The Character's health comes from here.

        /// Reduces the Health of the Character by one.
        public void TakeDamage()
        {
            --_character.Health;
        }

        /// Reduces the Health of the Character by a set amount.
        /*!
        \param damage is the damage you substract from your health.
        */
        public void TakeDamage(int damage = 1)
        {
            _character.Health -= damage;
        }

        /// Here we set the defaukt value of the Character.
        private void Awake() 
        {
            _character = GetComponent<ICharacter>();
        }
    }
}

