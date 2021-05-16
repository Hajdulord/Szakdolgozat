using UnityEngine;

namespace HMF.Thesis.Interfaces
{

    /// The interface for an item.
    public interface IItem
    {
        /// The name of the Item.
        string Name {get;}

        /// Is the Item Unique.
        bool Unique {get;}

        /// The displayed sprite of the item.
        Sprite Sprite {get;}

        /// The Target type of the item.
        TargetType TargetType {get;}

        /// The Descripton of the item.
        string Description {get;}

        /// The time between the uses of an item.
        float attackTime {get;}

        /// Use an item by this function.
        /*!
          \param origin is wher the attack comes from.
          \param tagsToTarget is a string array that holds all the tags the attack will target.
          \param layersToTarget is a LayerMask. You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
        */
        void Use(GameObject origin, string[] tagsToTarget, LayerMask layersToTarget);
    }

    /// An enum that defines the attack target types.
    public enum TargetType
    {
        Self,
        Other
    }
}
