using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Status.ActualStatuses
{
    public class Stunned : StatusBase
    {
        public override string Name => "Stunned";

        public override float LifeTime => 40f;

        public override float EffectInterval => 40f;

        private float _damage = 10f;

        public override void Affect(GameObject gameObject)
        {
            var damageable = gameObject.GetComponent<IDamageableComponent>();
            damageable?.Damageable.TakeDamage(_damage);
            // TODO: implement movement lock!
        }
    }
}
