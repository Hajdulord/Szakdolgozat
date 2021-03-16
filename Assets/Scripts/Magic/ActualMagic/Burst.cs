using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using UnityEngine;

namespace HMF.Thesis.Magic.ActualMagic
{
    public class Burst : MagicBase
    {
        

        public override string Name => "Burst";

        public override void Use(string[] tagsToIgnore, MagicFocusData magicFocus, Vector2 center, float dir = 0)
        {
            var colliders = Physics2D.OverlapCircleAll(center, magicFocus.attackRange);

            foreach (var item in colliders)
            {
                var ignore = false;
                foreach(var tag in tagsToIgnore)
                {
                    if (item.tag == tag)
                    {
                        ignore = true;
                    }
                }

                if (!ignore)
                {
                    var damageable = item.gameObject.GetComponent<IDamageableComponent>();
                    var statusHandler = item.gameObject.GetComponent<IStatusHandlerComponent>();

                    damageable.Damageable.TakeDamage(magicFocus.damage);
                    statusHandler.StatusHandler.AddStatus(magicFocus.status);
                }
            }
        }
    }
}
