using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Status.ActualStatuses
{
    public class Stunned : StatusBase
    {
        public override string Name => "Stunned";

        public override float LifeTime => 10f;

        public override float EffectInterval => 10f;

        private float _damage = 10f;

        public override void Affect(GameObject gameObject)
        {
            var damageable = gameObject.GetComponent<IDamageableComponent>();
            damageable?.Damageable.TakeDamage(_damage);
            Debug.Log("Affect");
        }

        public override void PrePhase(GameObject gameObject)
        {
            Debug.Log("Enter");
            var rigidbody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }

        public override void CloseUp(GameObject gameObject)
        {
            Debug.Log("Exit");
            var rigidbody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbody.constraints = RigidbodyConstraints2D.None;
                rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
