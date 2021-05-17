using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using UnityEngine;

namespace HMF.Thesis.Magic.ActualMagic
{
    /// A magic implementation that burst from the center.
    public class Burst : MagicBase
    {
        /// The Name of the magic.
        public override string Name => "Burst";

        /// Deals damage and add statuses in a circle.
        /*!
          \param tagsToTarget are the target tags.
          \param magicFocus is the data part of the magic.
          \param center is the center of the magic.
          \param layersToTarget are the target layers.
          \param animaton is the animation to play.
          \param dir is the direction of the magic.
        */
        public override void Use(string[] tagsToTarget, MagicFocusData magicFocus, Vector2 center, LayerMask layersToTarget, GameObject animation, float dir = 0)
        {
            Object.Instantiate(animation, center, Quaternion.identity);

            // target finding
            var colliders = Physics2D.OverlapCircleAll(center, magicFocus.attackRange, layersToTarget);

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
