using UnityEngine;
namespace HMF.Thesis.Interfaces
{
    /// The Interface for the MagicHandler.
    public interface IMagicHandler
    {
        /// You can use magic by this.
        /*!
          \param magic is the name of the magic.
          \param tagsToTarget is a string array that holds all the tags the attack will target.
          \param center is the center of the magic.
          \param layersToTarget is a LayerMask. You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
          \param animation is ta animation to play.
          \param dir is the direction of the magic.
        */
        void UseMagic(string magic, string[] tagsToTarget, Vector2 center, LayerMask layersToTarget,GameObject animation, float dir = 0);
    }
}
