using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Status.ActualStatuses
{
    /// A calss that implements a Burning statuseffect.
    public class Burning : StatusBase
    {
        /// The getter for the name of the status.
        public override string Name => "Burning";

        /// The getter for the lifetime of the status.
        public override float LifeTime => 60f;

        /// The getter for the interval of affecting.
        public override float EffectInterval => 25f;

        private float _damage = 5f; ///< The damage dealt everytime the Affect methode is called.

        /// Deals damage periodically.
        public override void Affect(GameObject gameObject)
        {
            var damageable = gameObject.GetComponent<IDamageableComponent>();

            damageable?.Damageable.TakeDamage(_damage);
        }

        /// Not needed for this status.
        public override void PrePhase(GameObject gameObject){}

        /// Not needed for this status.
        public override void CloseUp(GameObject gameObject){}
    }
}
