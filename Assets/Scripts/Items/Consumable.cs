using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Items
{
    /// The base class for the Consumables.
    public abstract class Consumable : IItem
    {

        /// The name of the Consumable.
        public abstract string Name {get; }

        /// Is the Consumable Unique.
        public abstract bool Unique {get; }

        /// The displayed sprite of the Consumable.
        public abstract Sprite Sprite {get; }

        /// The Target type of the Consumable.
        public abstract TargetType TargetType {get; }

        /// The Descripton of the Consumable.
        public abstract string Description {get; }

        /// The time between the uses of an Consumable.
        public abstract float attackTime {get; }

        /// Use an Consumable by this function.
        /*!
          \param origin is wher the attack comes from.
          \param tagsToTarget is a string array that holds all the tags the attack will target.
          \param layersToTarget is a LayerMask. You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
        */
        public abstract void Use(GameObject origin, string[] tagsToTarget, LayerMask layersToTarget);
    }
}
