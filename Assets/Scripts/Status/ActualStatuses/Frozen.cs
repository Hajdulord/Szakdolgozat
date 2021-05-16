using HMF.Thesis.Interfaces.ComponentInterfaces;
using UnityEngine;

namespace HMF.Thesis.Status.ActualStatuses
{
    /// A calss that implements a Freezing/Frozen statuseffect.
    public class Frozen : StatusBase
    {
        /// The getter for the name of the status.
        public override string Name => "Frozen";

        /// The getter for the lifetime of the status.
        public override float LifeTime => 60f;

        /// The getter for the interval of affecting.
        public override float EffectInterval => 15f;

        private float _damage = 1f; ///< The damage dealt everytime the Affect methode is called.

        private float _slow = 5f; ///< The amount that the target will be slowed.

        /// Deals damage periodically.
        public override void Affect(GameObject gameObject)
        {
            var damageable = gameObject.GetComponent<IDamageableComponent>();
            damageable?.Damageable.TakeDamage(_damage);
        }

        /// Decreeses the movement speed of the target.
        public override void PrePhase(GameObject gameObject)
        {
            var moveComponent = gameObject.GetComponent<IMoveComponent>();
            var move = moveComponent?.Move;

            if (move != null)
            {
                move.Speed =  Mathf.Max(1, move.Speed - _slow);
            }
        }

        /// Sets the target's speed to its default.
        public override void CloseUp(GameObject gameObject)
        {
            var moveComponent = gameObject.GetComponent<IMoveComponent>();
            var move = moveComponent?.Move;
            if (move != null)
            {
                move.Speed = move.BaseSpeed;
            }
        }
    }
}
