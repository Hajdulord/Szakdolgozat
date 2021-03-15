using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public Sprite sprite;
    }
}
