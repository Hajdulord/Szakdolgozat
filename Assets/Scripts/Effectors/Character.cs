using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Effectors
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Character : MonoBehaviour, ICharacter
    {
        [Header("Serializable Fields")]
        [SerializeField] private int _health;
        [SerializeField] private CharacterData _characterData = null;

        public CharacterData CharacterData { get => _characterData; set => _characterData = value; }

        public int Health { get => Mathf.Max(0, _health); set => _health = Mathf.Min(Mathf.Max(0, value), MaxHealth); }

        public int MaxHealth => _characterData.maxHealth;

        public string CharacterName => _characterData.characterName;


        private void Awake() 
        {
            if(CharacterData != null)
            {
                GetComponent<SpriteRenderer>().sprite = _characterData.sprite;
                _health = _characterData.maxHealth;
            }
            
        }
    }
}
