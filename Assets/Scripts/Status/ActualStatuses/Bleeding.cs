using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Status.ActualStatuses
{
    /// Class that implements a bleeding statuseffect.
    public class Bleeding : StatusBase
    {
        /// The getter for the name of the status.
        public override string Name => "Bleeding";

        /// The getter for the lifetime of the status.
        public override float LifeTime => 100;

        /// The getter for the interval of affecting.
        public override float EffectInterval => 20;

        private float _damage = 1f; ///< The damage dealt everytime the Affect methode is called.

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
