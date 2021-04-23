using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Items
{
    public class Weapon : IItem
    {
        private WeaponData _weaponData;

        public string Name => _weaponData.name;
        public string Description => _weaponData.description;
        public bool Unique => _weaponData.isUnique;
        public Sprite Sprite => _weaponData.sprite;
        public TargetType TargetType => _weaponData.targetType;
        public float attackTime => _weaponData.attackTime;

        public Weapon(WeaponData weaponData)
        {
            _weaponData = weaponData;
        }

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
