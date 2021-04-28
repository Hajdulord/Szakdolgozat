using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Status.ActualStatuses
{
    public class Stunned : StatusBase
    {
        public override string Name => "Stunned";

        public override float LifeTime => 5f;

        public override float EffectInterval => 4f;

        private float _damage = 10f;

        public override void Affect(GameObject gameObject)
        {
            var damageable = gameObject.GetComponent<IDamageableComponent>();
            damageable?.Damageable.TakeDamage(_damage);
        }

        public override void PrePhase(GameObject gameObject)
        {
            var rigidbody = gameObject.GetComponent<Rigidbody2D>();
            //Debug.Log(rigidbody);
            if (rigidbody != null)
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                //Debug.Log("lock");
            }

            var player = gameObject.GetComponent<IPlayerStateMachine>();

            if (player != null)
            {
                player.IsStunned = true;
            }
        }

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
