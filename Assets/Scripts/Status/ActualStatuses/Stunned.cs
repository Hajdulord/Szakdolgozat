using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Status.ActualStatuses
{
    /// A calss that implements a Stunnig/Stunned statuseffect.
    public class Stunned : StatusBase
    {
        /// The getter for the name of the status.
        public override string Name => "Stunned";

        /// The getter for the lifetime of the status.
        public override float LifeTime => 5f;

        /// The getter for the interval of affecting.
        public override float EffectInterval => 4f;

        private float _damage = 10f; ///< The damage dealt everytime the Affect methode is called.

        /// Deals damage periodically.
        public override void Affect(GameObject gameObject)
        {
            var damageable = gameObject.GetComponent<IDamageableComponent>();
            damageable?.Damageable.TakeDamage(_damage);
        }

        /// Locks the target in place.
        public override void PrePhase(GameObject gameObject)
        {
            var rigidbody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                /// set movement constraints
                rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }

            var player = gameObject.GetComponent<IPlayerStateMachine>();

            if (player != null)
            {
                player.IsStunned = true;
            }
        }

        /// Reverts to default movement constrains.
        public override void CloseUp(GameObject gameObject)
        {
            var rigidbody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbody.constraints = RigidbodyConstraints2D.None;
                rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }

            var player = gameObject.GetComponent<IPlayerStateMachine>();

            if (player != null)
            {
                player.IsStunned = false;
            }
        }
    }
}
