using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Status.ActualStatuses
{
    public class Burning : StatusBase
    {
        public override string Name => "Burning";

        public override float LifeTime => 60f;

        public override float EffectInterval => 25f;

        private float _damage = 5f;

        public override void Affect(GameObject gameObject)
        {
            var damageable = gameObject.GetComponent<IDamageableComponent>();

            damageable?.Damageable.TakeDamage(_damage);
        }
    }
}
