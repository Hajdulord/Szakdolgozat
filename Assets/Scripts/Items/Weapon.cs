using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Items
{
    /// Class for the weapons.
    public class Weapon : IItem
    {
        private WeaponData _weaponData; ///< Data of a Weapon.

        /// The name of the Weapon.
        public string Name => _weaponData.name;

        /// The Descripton of the Weapon.
        public string Description => _weaponData.description;

        /// Is the Weapon Unique.
        public bool Unique => _weaponData.isUnique;

        /// The displayed sprite of the Weapon.
        public Sprite Sprite => _weaponData.sprite;

        /// The Target type of the Weapon.
        public TargetType TargetType => _weaponData.targetType;

        /// The time between the uses of an Weapon.
        public float attackTime => _weaponData.attackTime;

        /// Constructor to set the _weaponData.
        public Weapon(WeaponData weaponData)
        {
            _weaponData = weaponData;
        }

        /// Damages and adds statuseffects to all target in a radius.
        /*!
          \param origin is wher the attack comes from.
          \param tagsToTarget is a string array that holds all the tags the attack will target.
          \param layersToTarget is a LayerMask. You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
        */
        public void Use(GameObject origin, string[] tagsToTarget, LayerMask layersToTarget)
        {
            var colliders = Physics2D.OverlapCircleAll(origin.transform.position, _weaponData.attackRange, layersToTarget);

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

                    damageable?.Damageable.TakeDamage(_weaponData.damage);
                    statusHandler?.StatusHandler.AddStatus(_weaponData.status.ToString());
                }
            }
        }
    }
}
