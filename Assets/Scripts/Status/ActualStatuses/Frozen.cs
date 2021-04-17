using System.Collections;
using System.Collections.Generic;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using UnityEngine;

namespace HMF.Thesis.Status.ActualStatuses
{
    public class Frozen : StatusBase
    {
        public override string Name => "Frozen";

        public override float LifeTime => 60f;

        public override float EffectInterval => 15f;

        private float _damage = 1f;

        private float _slow = 5f;

        public override void Affect(GameObject gameObject)
        {
            var damageable = gameObject.GetComponent<IDamageableComponent>();
            damageable?.Damageable.TakeDamage(_damage);
        }

        public override void PrePhase(GameObject gameObject)
        {
            var moveComponent = gameObject.GetComponent<IMoveComponent>();
            var move = moveComponent?.Move;

            if (move != null)
            {
                move.Speed -= _slow;
            }
        }

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