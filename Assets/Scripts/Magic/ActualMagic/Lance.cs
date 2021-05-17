using HMF.Thesis.Interfaces.ComponentInterfaces;
using UnityEngine;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Magic.ActualMagic
{
    /// A magic implementation that is a lacne starting from the center.
    public class Lance : MagicBase
    {
        /// The Name of the magic.
        public override string Name => "Lance";

        /// Deals damage and add statuses in a rectangle.
        /*!
          \param tagsToTarget are the target tags.
          \param magicFocus is the data part of the magic.
          \param center is the start of the magic.
          \param layersToTarget are the target layers.
          \param animaton is the animation to play.
          \param dir is the direction of the magic.
        */
        public override void Use(string[] tagsToTarget, MagicFocusData magicFocus, Vector2 center, LayerMask layersToTarget, GameObject animation, float dir)
        {
            var anim = Object.Instantiate(animation, new Vector3(center.x + dir * 2, center.y, 0), Quaternion.identity);
            anim.transform.right = Vector2.right * dir;

            // calculating endpoint
            var point = new Vector2(center.x + dir * magicFocus.attackRange, center.y + magicFocus.attackRange / 2);
            
            // target finding
            var colliders = Physics2D.OverlapAreaAll(center, point, layersToTarget);

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
