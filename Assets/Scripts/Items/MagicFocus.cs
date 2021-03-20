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

        public MagicFocus(MagicFocusData magicFocusData, MagicHandler magicHandler)
        {
            _magicFocusData = magicFocusData;
            _magicHandler = magicHandler;
        }

        public void Use(GameObject origin, string[] tagsToTarget)
        {
            _magicHandler.UseMagic(_magicFocusData.magicType, tagsToTarget, origin.transform.position, origin.transform.forward.x);
        }
    }
}
