using UnityEngine;
using HMF.Thesis.Interfaces;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Logic
{
    public class CharacterLogic : ICharacter
    {
        private int _health;
        private CharacterData _characterData = null;

        public CharacterLogic(CharacterData character)
        {
            _characterData = character;
            _health = _characterData.maxHealth;
        }

        public int Health { get => Mathf.Max(0, _health); set => _health = Mathf.Min(Mathf.Max(0, value), MaxHealth); }

        public int MaxHealth => _characterData.maxHealth;

        public string CharacterName => _characterData.characterName;

        public Sprite CharacterSprite => _characterData.sprite;
    }
}
