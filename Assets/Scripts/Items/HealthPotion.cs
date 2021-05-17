using UnityEngine;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Items
{
    /// Class for a potion that heals its target.
    public class HealthPotion : Consumable
    {
        private ConsumableData _consumableData; ///< Data of a Consumable.

        /// The name of the HealthPotion.
        public override string Name => _consumableData.consumableName;

        /// Is the HealthPotion Unique.
        public override bool Unique => _consumableData.isUnique;
        
        /// The displayed sprite of the HealthPotion.
        public override Sprite Sprite => _consumableData.sprite;

        /// The Target type of the HealthPotion.
        public override TargetType TargetType => _consumableData.targetType;

        /// The Descripton of the HealthPotion.
        public override string Description => _consumableData.description;

        /// The time between the uses of an HealthPotion.
        public override float attackTime => _consumableData.attackTime;

        /// Constructor to set the _consumableData.
        public HealthPotion(ConsumableData consumable)
        {
            _consumableData = consumable;
        }

        /// Heals the target and adds a healing status.
        /*!
          \param origin is wher the attack comes from.
          \param tagsToTarget is a string array that holds all the tags the attack will target.
          \param layersToTarget is a LayerMask. You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
        */
        public override void Use(GameObject origin, string[] tagsToTarget, LayerMask layersToTarget)
        {
            var healable = origin.GetComponent<IHealableComponent>()?.Healable;

            healable.Heal(_consumableData.affectAmount);

            var status = origin.GetComponent<IStatusHandlerComponent>()?.StatusHandler;

            status.AddStatus(_consumableData.status.ToString());
        }
    }
}
