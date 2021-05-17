using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Interfaces.ComponentInterfaces;

namespace HMF.Thesis.Items
{
    /// Class for a potion that cures all statuseffects.
    public class CurePotion : Consumable
    {
        private ConsumableData _consumableData; ///< Data of a Consumable.

        /// The name of the CurePotion.
        public override string Name => _consumableData.consumableName;

        /// Is the CurePotion Unique.
        public override bool Unique => _consumableData.isUnique;

        /// The displayed sprite of the CurePotion.
        public override Sprite Sprite => _consumableData.sprite;

        /// The Target type of the CurePotion.
        public override TargetType TargetType => _consumableData.targetType;

        /// The Descripton of the CurePotion.
        public override string Description => _consumableData.description;

        /// The time between the uses of an CurePotion.
        public override float attackTime => _consumableData.attackTime;

        /// Constructor to set the _consumableData.
        public CurePotion(ConsumableData consumable)
        {
            _consumableData = consumable;
        }

        /// Removes all statuses.
        /*!
          \param origin is wher the attack comes from.
          \param tagsToTarget is a string array that holds all the tags the attack will target.
          \param layersToTarget is a LayerMask. You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
        */
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
