using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using HMF.Thesis.Effectors;
using HMF.Thesis.ScriptableObjects;

namespace HMF.Thesis.Tests
{
    /// Tests for the Character class.
    public class CharacterTest
    {
        /// Tests for the property CharacterData
        [Test]
        public void CharacterDataTest()
        {
            //* Setup
            var dummyGameObject = new GameObject();
            var character = dummyGameObject.AddComponent<Character>();
            var characterData = ScriptableObject.CreateInstance<CharacterData>();
            characterData.maxHealth = 5;

            //* Tests
            Assert.Null(character.CharacterData);

            character.CharacterData = characterData;

            Assert.AreEqual(characterData, character.CharacterData);

        }

        /// Tests for the property MaxHealth
        [Test]
        public void MaxHealthTest()
        {
            //* Setup
            var dummyGameObject = new GameObject();
            var character = dummyGameObject.AddComponent<Character>();
            var characterData = ScriptableObject.CreateInstance<CharacterData>();
            characterData.maxHealth = 5;
            character.CharacterData = characterData;

            //* Tests
            Assert.AreEqual(5, character.MaxHealth);

        }

        /// Tests for the property Health
        [Test]
        public void HealthTest()
        {
            //* Setup
            var dummyGameObject = new GameObject();
            var character = dummyGameObject.AddComponent<Character>();
            var characterData = ScriptableObject.CreateInstance<CharacterData>();
            characterData.maxHealth = 5;
            character.CharacterData = characterData;

            //* Tests
            Assert.AreEqual(0, character.Health); //* Because Character data is null in Awake and it is not assign.

            character.Health = 6;

            Assert.AreEqual(5, character.Health);

            character.Health = 5;

            Assert.AreEqual(5, character.Health);
            
            character.Health = -1;

            Assert.AreEqual(0, character.Health);
        }

        /// Tests for the property CharacterName
        [Test]
        public void CharacterName()
        {
            //* Setup
            var dummyGameObject = new GameObject();
            var character = dummyGameObject.AddComponent<Character>();
            var characterData = ScriptableObject.CreateInstance<CharacterData>();
            characterData.characterName = "Bela";
            character.CharacterData = characterData;

            //* Tests
            Assert.AreEqual("Bela", character.CharacterName);

        }
    }
}
