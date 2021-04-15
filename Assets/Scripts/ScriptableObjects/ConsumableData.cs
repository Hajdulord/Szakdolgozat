using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable")]
    public class ConsumableData : ScriptableObject
    {
        public string consumableName;
        public string description;
        public int affectAmount;
        public float affectRange;
        public float affectRate;
        public string status;
        public string magicType;
        public Sprite sprite;
        public TargetType targetType;
        public bool isUnique;
        public float attackTime;
        public GameObject animationToSpawn;
    }
}
