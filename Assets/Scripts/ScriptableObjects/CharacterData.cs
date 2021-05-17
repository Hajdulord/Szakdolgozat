using UnityEngine;

namespace HMF.Thesis.ScriptableObjects
{
    /// Data of a character.
    [CreateAssetMenu(menuName = "Character")]
    public class CharacterData : ScriptableObject
    {
        public string characterName;
        public int maxHealth;
        public int baseSpeed;
        public Sprite sprite;
    }
}
