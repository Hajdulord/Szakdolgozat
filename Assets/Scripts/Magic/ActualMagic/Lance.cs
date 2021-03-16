using HMF.Thesis.Interfaces.ComponentInterfaces;
using UnityEngine;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Magic.ActualMagic
{
    public class Lance : MagicBase
    {
        public override string Name => "Lance";

        public override void Use(string[] tagsToTarget, MagicFocusData magicFocus, Vector2 center, float dir)
        {
            var point = new Vector2(center.x + dir * magicFocus.attackRange / 2, center.y);
            var colliders = Physics2D.OverlapAreaAll(center, new Vector2(center.x + magicFocus.attackRange, magicFocus.attackRange / 2));

            foreach (var item in colliders)
            {
                var toTarget = false;
                foreach(var tag in tagsToTarget)
                {
                    if (item.tag == tag)
                    {
                        toTarget = true;
                    }
                }

                if (toTarget)
                {
                    var damageable = item.gameObject.GetComponent<IDamageableComponent>();
                    var statusHandler = item.gameObject.GetComponent<IStatusHandlerComponent>();

                    damageable?.Damageable.TakeDamage(magicFocus.damage);
                    statusHandler?.StatusHandler.AddStatus(magicFocus.status);
                }
            }
        }
    }
}
