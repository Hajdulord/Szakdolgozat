using UnityEngine;

namespace HMF.Thesis.Interfaces
{
    /// An interface for an Attack logic.
    public interface IAttack
    {
        /// The property for the Origin of the attack. It is a GameObject so the neccessary components could be acquired.
        GameObject Origin { get; set; }

        /// The attack function.
        /*!
          \param item isn an IItem. This holds the attack logic.
          \param tagsToTarget is a string array that holds all the tags the attack will target.
          \param layersToTarget is a LayerMask. You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
        */
        void Attack(IItem item, string[] tagsToTarget, LayerMask layersToTarget);
    }
}
