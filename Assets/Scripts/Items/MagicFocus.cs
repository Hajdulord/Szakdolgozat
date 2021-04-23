using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Magic;

namespace HMF.Thesis.Items
{
    public class MagicFocus : IItem
    {
        private MagicFocusData _magicFocusData;
        private MagicHandler _magicHandler;

        public string Name => _magicFocusData.name;
        public string Description => _magicFocusData.description;
        public bool Unique => _magicFocusData.isUnique;
        public Sprite Sprite => _magicFocusData.sprite;
        public TargetType TargetType => _magicFocusData.targetType;
        public float attackTime => _magicFocusData.attackTime;
        public AudioClip Clip => _magicFocusData.clip;

        public MagicFocus(MagicFocusData magicFocusData, IMagicHandler magicHandler)
        {
            _magicFocusData = magicFocusData;
            _magicHandler = magicHandler as MagicHandler;
            _magicHandler.AddNewMagic(_magicFocusData.magicType.ToString(), _magicFocusData);
        }

        public void Use(GameObject origin, string[] tagsToTarget, LayerMask layersToTarget)
        {
            _magicHandler.UseMagic(
                _magicFocusData.magicType.ToString(), 
                tagsToTarget, origin.transform.position, 
                layersToTarget, 
                _magicFocusData.animationToSpawn, 
                origin.transform.right.x);
        }
    }
}
