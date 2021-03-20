using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
    public class WeaponData :ScriptableObject
    {
        public string weaponName;
        public string description;
        public int damage;
        public float attackRange;
        public float attackRate;
        public string status;
        public Sprite sprite;
        public TargetType targetType;
        public bool isUnique;
        public float attackTime;

    }
}
