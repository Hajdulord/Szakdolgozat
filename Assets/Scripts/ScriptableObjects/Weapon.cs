using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
    public class Weapon : Item
    {
        public int damage;
        public float attackRange;
        public float attackRate;
        public Status status;

        public override void Use(GameObject gameObject)
        {
            var damageable = gameObject.GetComponent<IDamageableComponent>();
            var statusHandler = gameObject.GetComponent<IStatusHandlerComponent>();

            damageable?.Damageable.TakeDamage(damage);
            
            if(status != Status.None)
                statusHandler?.StatusHandler.AddStatus(status.ToString());
        }

    }
}
