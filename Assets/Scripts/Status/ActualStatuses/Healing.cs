using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Status.ActualStatuses
{
    public class Healing : StatusBase
    {
        public override string Name => "Healing";

        public override float LifeTime => 60f;

        public override float EffectInterval => 10f;
        
        private float _healAmount = 3f;

        public override void Affect(GameObject gameObject)
        {
            var healable = gameObject.GetComponent<IHealableComponent>();
            healable?.Healable.Heal(_healAmount);
        }

        public override void PrePhase(GameObject gameObject)
        {
            
        }

        public override void CloseUp(GameObject gameObject)
        {
            
        }
    }
}
