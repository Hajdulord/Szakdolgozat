using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Items
{

    public class HealthPotion : IItem
    {
        private ConsumableData _consumableData;

        public string Name => _consumableData.consumableName;

        public bool Unique => _consumableData.isUnique;

        public Sprite Sprite => _consumableData.sprite;

        public TargetType TargetType => _consumableData.targetType;

        public string Description => _consumableData.description;

        public float attackTime => _consumableData.attackTime;

        public HealthPotion(ConsumableData consumable)
        {
            _consumableData = consumable;
        }

        public void Use(GameObject origin, string[] tagsToTarget)
        {
            var healable = origin.GetComponent<IHealableComponent>()?.Healable;

            healable.Heal(_consumableData.affectAmount);

            var status = origin.GetComponent<IStatusHandlerComponent>()?.StatusHandler;

            status.AddStatus(_consumableData.status.ToString());
        }
    }
}
