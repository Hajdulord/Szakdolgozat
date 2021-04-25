using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Items
{
    public class CurePotion : Consumable
    {
        private ConsumableData _consumableData;

        public override string Name => _consumableData.consumableName;
        public override bool Unique => _consumableData.isUnique;
        public override Sprite Sprite => _consumableData.sprite;
        public override TargetType TargetType => _consumableData.targetType;
        public override string Description => _consumableData.description;
        public override float attackTime => _consumableData.attackTime;

        public CurePotion(ConsumableData consumable)
        {
            _consumableData = consumable;
        }


        public override void Use(GameObject origin, string[] tagsToTarget, LayerMask layersToTarget)
        {
            var status = origin.GetComponent<IStatusHandlerComponent>()?.StatusHandler;

            if (status != null)
            {
                status.RemoveAllStatuses();
            }
        }
    }
}
