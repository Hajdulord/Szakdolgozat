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

        public string Name { get => _magicFocusData.name; }
        public string Description {get => _magicFocusData.description; }
        public bool Unique { get => _magicFocusData.isUnique; }
        public Sprite Sprite { get => _magicFocusData.sprite; }
        public TargetType TargetType { get => _magicFocusData.targetType; }

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
