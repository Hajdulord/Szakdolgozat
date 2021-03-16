using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Items/Magic Focus")]
    public class MagicFocusData : ScriptableObject
    {
        public string magicName;
        public string description;
        public int damage;
        public float attackRange;
        public float attackRate;
        public string status;
        public string magicType;
        public Sprite sprite;
        public TargetType targetType;
        public bool isUnique;
    }
}
