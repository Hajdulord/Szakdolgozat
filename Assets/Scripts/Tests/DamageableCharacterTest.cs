using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using HMF.Thesis.Effectors;
using HMF.Thesis.ScriptableObjects;
using Moq;

namespace HMF.Thesis.Tests
{
    /// Tets for the Damageable class.
    public class DamageableCharacterTest
    {
        /// Test for TakeDamage without an input damage.
        [Test]
        public void TakeDamageTest()
        {
            //* Setup
            var dummyGameObject = new GameObject();
            var player = dummyGameObject.AddComponent<Character>();
            var characterData = ScriptableObject.CreateInstance<CharacterData>();
            characterData.maxHealth = 5;
            player.CharacterData = characterData;

            var damageable = dummyGameObject.AddComponent<DamageableCharacter>();

            player.Health = 5;

            //* Testing
            Assert.AreEqual(5, player.Health);

            damageable.TakeDamage();

            Assert.AreEqual(4, player.Health);
        }

        /// Test for TakeDamage with an input damage.
        [Test]
        public void TakeDamageWithInputTest()
        {
            //* Setup
            var dummyGameObject = new GameObject();
            var player = dummyGameObject.AddComponent<Character>();
            var characterData = ScriptableObject.CreateInstance<CharacterData>();
            characterData.maxHealth = 5;
            player.CharacterData = characterData;

            var damageable = dummyGameObject.AddComponent<DamageableCharacter>();

            player.Health = 5;

            //* Testing
            Assert.AreEqual(5, player.Health);

            damageable.TakeDamage(2);

            Assert.AreEqual(3, player.Health);
        }
    }
}
