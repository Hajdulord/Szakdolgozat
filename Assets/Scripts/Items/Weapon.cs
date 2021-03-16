using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Status;

namespace HMF.Thesis.Items
{
    public class Weapon : IItem
    {
        private WeaponData _weaponData;
        private StatusHandler _statusHandler;

        public string Name { get => _weaponData.name; }
        public string Description {get => _weaponData.description; }
        public bool Unique { get => _weaponData.isUnique; }
        public Sprite Sprite { get => _weaponData.sprite; }
        public TargetType TargetType { get => _weaponData.targetType; }

        public Weapon(WeaponData weaponData, StatusHandler statusHandler)
        {
            _weaponData = weaponData;
            _statusHandler = statusHandler;
        }

        public void Use(GameObject origin, string[] tagsToTarget)
        {
            var colliders = Physics2D.OverlapCircleAll(origin.transform.position, _weaponData.attackRange);

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

                    damageable?.Damageable.TakeDamage(_weaponData.damage);
                    statusHandler?.StatusHandler.AddStatus(_weaponData.status);
                }
            }
        }
    }
}
