using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using HMF.Thesis.ScriptableObjects;
using HMF.Thesis.Logic;

namespace HMF.Thesis.Tests
{
    /// Tests for the Characterlogic class.
    public class CharacterLogicTest
    {
        

        /// Tests for the property MaxHealth
        [Test]
        public void MaxHealthReturnsExpectedValue()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();
            data.maxHealth = 5;

            var character = new CharacterLogic(data);

            //* Tests
            Assert.AreEqual(5, character.MaxHealth);

        }

        /// Tests if the health's default value is set correctly.
        [Test]
        public void HealthDeafultValue()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();
            data.maxHealth = 5;

            var character = new CharacterLogic(data);

            //* Tests
            Assert.AreEqual(5, character.Health);
        }

        /// Tests if returns expected value after setting it between correct range.
        [Test]
        public void HealthValueSetReturnsExpected()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();
            data.maxHealth = 5;

            var character = new CharacterLogic(data);

            //* Affect
            character.Health = 3;

            //* Tests
            Assert.AreEqual(3, character.Health);
        }

        /// Tests if returns expected value after setting it lower than 0.
        [Test]
        public void HealthValueSetReturnsExpectedAfterSettingItNegative()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();
            data.maxHealth = 5;

            var character = new CharacterLogic(data);

            //* Affect
            character.Health = -1;

            //* Tests
            Assert.AreEqual(0, character.Health);
        }

        /// Tests if returns expected value after setting it ower MaxHealth.
        [Test]
        public void HealthValueSetReturnsExpectedAfterSettingItOverMaxHealth()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();
            data.maxHealth = 5;

            var character = new CharacterLogic(data);

            //* Affect
            character.Health = 6;

            //* Tests
            Assert.AreEqual(5, character.Health);
        }

        /// Tests for the property CharacterName
        [Test]
        public void CharacterName()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();
            data.maxHealth = 5;
            data.characterName = "Bob";

            var character = new CharacterLogic(data);

            //* Tests
            Assert.AreEqual("Bob", character.CharacterName);

        }

        /// Tests for the property CharacterName
        [Test]
        public void CharacterSprite()
        {
            //* Setup
            var data = ScriptableObject.CreateInstance<CharacterData>();
            data.maxHealth = 5;

            var sprite = Sprite.Create(new Texture2D(50, 50), new Rect(), Vector2.zero);

            data.sprite = sprite;

            var character = new CharacterLogic(data);

            //* Tests
            Assert.AreEqual(sprite, character.CharacterSprite);

        }
    }
}
