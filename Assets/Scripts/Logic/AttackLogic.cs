using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.Logic
{
    /// The Logic behind an attack.
    public class AttackLogic : IAttack
    {
        public GameObject Origin {get; set;} ///< Origin of the attack

        /// Constructor to set Origin.
        public AttackLogic(GameObject origin)
        {
            Origin = origin;
        }

        /// Makes an attack.
        /*!
          \param item isn an IItem. This holds the attack logic.
          \param tagsToTarget is a string array that holds all the tags the attack will target.
          \param layersToTarget is a LayerMask. You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
        */
        public void Attack(IItem item, string[] tagsToTarget, LayerMask layersToTarget)
        {
            item.Use(Origin, tagsToTarget, layersToTarget);
        }
    }
}
