using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Needs Comments.
namespace HMF.Thesis.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Character")]
    public class CharacterData : ScriptableObject
    {
        public string characterName;
        public int maxHealth;
        public int baseSpeed;
        public Sprite sprite;
    }
}
