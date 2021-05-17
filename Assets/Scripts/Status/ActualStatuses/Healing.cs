using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Status.ActualStatuses
{
    /// A class that implements a Healing statuseffect.
    public class Healing : StatusBase
    {
        /// The getter for the name of the status.
        public override string Name => "Healing";

        /// The getter for the lifetime of the status.
        public override float LifeTime => 60f;

        /// The getter for the interval of affecting.
        public override float EffectInterval => 10f;
        
        private float _healAmount = 3f; ///< The amount healed everytime the Affect methode is called.

        /// Heals periodically
        public override void Affect(GameObject gameObject)
        {
            var healable = gameObject.GetComponent<IHealableComponent>();
            healable?.Healable.Heal(_healAmount);
        }

        /// Not needed for this status.
        public override void PrePhase(GameObject gameObject){}

        /// Not needed for this status.
        public override void CloseUp(GameObject gameObject){}
    }
}
