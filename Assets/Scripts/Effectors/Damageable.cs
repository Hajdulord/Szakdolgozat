using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Effectors
{
    /// A class for objects that are damageable.
    public class Damageable : MonoBehaviour, IDamageable
    {
            private IEntity _enity = null!; ///< The IEntity's data.

            /// Reduces the Health of the IEntity by one.
            public void TakeDamage()
            {
                --_enity.Health;
            }

            /// Reduces the Health of the IEntity by a set amount.
            /*!
            \param damage is the damage you substract from your health.
            */
            public void TakeDamage(int damage = 1)
            {
                _enity.Health -= damage;
            }

            /// Here we set the defaukt value of the _enitiy.
            private void Awake() 
            {
                _enity = GetComponent<IEntity>();
            }
    }
}

