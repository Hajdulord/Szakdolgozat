using UnityEngine;
using HMF.Thesis.Interfaces;

namespace HMF.Thesis.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Magic Focus", menuName = "Items/Magic Focus")]
    public class MagicFocusData : ScriptableObject
    {
        public string magicName;
        public string description;
        public int damage;
        public float attackRange;
        public float attackRate;
        public Enums.Statuses status;
        public Enums.Magics magicType;
        public Sprite sprite;
        public TargetType targetType;
        public bool isUnique;
        public float attackTime;
        public GameObject animationToSpawn;
    }
}
