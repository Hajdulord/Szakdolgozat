using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using UnityEngine;

namespace HMF.Thesis.Magic.ActualMagic
{
    public class Burst : MagicBase
    {
        

        public override string Name => "Burst";

        public override void Use(string[] tagsToTarget, MagicFocusData magicFocus, Vector2 center, GameObject animation, float dir = 0)
        {
            Object.Instantiate(animation, center, Quaternion.identity);

            var colliders = Physics2D.OverlapCircleAll(center, magicFocus.attackRange);

            foreach (var item in colliders)
            {
                var toTarget = false;
                foreach(var tag in tagsToTarget)
                {
                    if (!item.isTrigger && item.tag == tag)
                    {
                        toTarget = true;
                    }
                }

                if (toTarget)
                {
                    var damageable = item.gameObject.GetComponent<IDamageableComponent>();
                    var statusHandler = item.gameObject.GetComponent<IStatusHandlerComponent>();

                    damageable?.Damageable.TakeDamage(magicFocus.damage);
                    statusHandler?.StatusHandler.AddStatus(magicFocus.status.ToString());
                }
            }
        }
    }
}
