using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Items
{

    public class HealthPotion : Consumable
    {
        private ConsumableData _consumableData;

        public override string Name => _consumableData.consumableName;

        public override bool Unique => _consumableData.isUnique;

        public override Sprite Sprite => _consumableData.sprite;

        public override TargetType TargetType => _consumableData.targetType;

        public override string Description => _consumableData.description;

        public override float attackTime => _consumableData.attackTime;

        public HealthPotion(ConsumableData consumable)
        {
            _consumableData = consumable;
        }

        public override void Use(GameObject origin, string[] tagsToTarget, LayerMask layersToTarget)
        {
            var healable = origin.GetComponent<IHealableComponent>()?.Healable;

            healable.Heal(_consumableData.affectAmount);

            var status = origin.GetComponent<IStatusHandlerComponent>()?.StatusHandler;

            status.AddStatus(_consumableData.status.ToString());
        }
    }
}
