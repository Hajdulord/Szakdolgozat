using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Status.ActualStatuses
{
    public class Bleeding : StatusBase
    {
        public override string Name => "Bleeding";

        public override float LifeTime => 100;

        public override float EffectInterval => 20;

        private float _damage = 2f;

        public override void Affect(GameObject gameObject)
        {
            var damageable = gameObject.GetComponent<IDamageableComponent>();

            damageable?.Damageable.TakeDamage(_damage);
        }

        public override void PrePhase(GameObject gameObject)
        {
            
        }

        public override void CloseUp(GameObject gameObject)
        {
            
        }

    }
}
