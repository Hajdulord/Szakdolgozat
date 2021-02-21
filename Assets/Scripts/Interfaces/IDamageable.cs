using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Interface for objects that are damageable.
public interface IDamageable
{
    /// Damage reduction for singel damage.
    void TakeDamage();
    /// Reduces the Health of the Player by a set amount.
    /*!
        \param damage is the damage you substract from your health.
    */
    void TakeDamage(int damage = 1);
}
