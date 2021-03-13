using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Components;

namespace HMF.Thesis.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
    public class Weapon : Item
    {
        public int damage;
        public float attackRate;
        public Status status;

        public override void Use(GameObject gameObject)
        {
            var damageable = gameObject.GetComponent<IDamageable>();
            var statusHandler = gameObject.GetComponent<StatusHandlerComponent>();

            damageable?.TakeDamage(damage);
            
            if(status != Status.None)
                statusHandler?.StatusHandler.AddStatus(status.ToString());
        }
    }
}
