using HMF.Thesis.Interfaces;
using UnityEngine;

namespace HMF.Thesis.ScriptableObjects
{
    /// Data of a weapon.
    [CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        public string description;
        public int damage;
        public float attackRange;
        public float attackRate;
        public Enums.Statuses status;
        public Sprite sprite;
        public TargetType targetType;
        public bool isUnique;
        public float attackTime;

    }
}
