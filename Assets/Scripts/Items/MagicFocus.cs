using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Interfaces.ComponentInterfaces;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Magic;

namespace HMF.Thesis.Items
{
    /// The class for magicFocuses.
    public class MagicFocus : IItem
    {
        private MagicFocusData _magicFocusData; ///< Data of a magicFocus.

        /// The name of the MagicFocus.
        public string Name => _magicFocusData.name;

        /// The Descripton of the MagicFocus.
        public string Description => _magicFocusData.description;

        /// Is the MagicFocus Unique.
        public bool Unique => _magicFocusData.isUnique;

        /// The displayed sprite of the MagicFocus.
        public Sprite Sprite => _magicFocusData.sprite;

        /// The Target type of the MagicFocus.
        public TargetType TargetType => _magicFocusData.targetType;

        /// The time between the uses of an MagicFocus.
        public float attackTime => _magicFocusData.attackTime;

        /// The audioclip to play when the magic has been cast.
        public AudioClip Clip => _magicFocusData.clip;

        /// Constructor to set the _magicFocusData.
        public MagicFocus(MagicFocusData magicFocusData)
        {
            _magicFocusData = magicFocusData;
        }

        /// Adds the new magic to the magicHandler and casts the magic.
        /*!
          \param origin is wher the attack comes from.
          \param tagsToTarget is a string array that holds all the tags the attack will target.
          \param layersToTarget is a LayerMask. You can set it to the lyers you want to target. It makes the target finding faster, than just tag based identifying.
        */
        public void Use(GameObject origin, string[] tagsToTarget, LayerMask layersToTarget)
        {
            var magicHandler = origin.gameObject.GetComponent<IMagicHandlerComponent>()?.MagicHandler as MagicHandler;

            if (magicHandler != null)
            {
                magicHandler.AddNewMagic(_magicFocusData.magicType.ToString(), _magicFocusData);
                
                magicHandler.UseMagic(
                    _magicFocusData.magicType.ToString(), 
                    tagsToTarget, origin.transform.position, 
                    layersToTarget, 
                    _magicFocusData.animationToSpawn, 
                    origin.transform.right.x);
            }
        }
    }
}
