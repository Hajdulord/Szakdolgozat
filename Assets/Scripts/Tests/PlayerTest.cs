using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using HMF.Thesis.Player;

namespace HMF.Thesis.Tests
{
    /// Tests for the PlayerItems class
    public class PlayerTest
    {
        /// Testing property logic of Health
        [Test]
        public void HealthTest()
        {
            GameObject dummy = new GameObject();

            dummy.AddComponent<PlayerItems>();

            Assert.AreEqual(5, dummy.GetComponent<PlayerItems>().Health);
        }

        /// Testing property logic of Speed
        [Test]
        public void SpeedTest()
        {
            GameObject dummy = new GameObject();

            dummy.AddComponent<PlayerItems>();

            var playerItem = dummy.GetComponent<PlayerItems>();

            Assert.AreEqual(10, playerItem.Speed);

            playerItem.Speed = 4;

            Assert.AreEqual(4, playerItem.Speed);

            playerItem.Speed = -4;

            Assert.AreEqual(0, playerItem.Speed);
        }

        /// Testing property logic of JumpForce
        [Test]
        public void JumpForceTest()
        {
            GameObject dummy = new GameObject();

            dummy.AddComponent<PlayerItems>();

            var playerItem = dummy.GetComponent<PlayerItems>();

            Assert.AreEqual(5, playerItem.JumpForce);

            playerItem.JumpForce = 4;

            Assert.AreEqual(4, playerItem.JumpForce);

            playerItem.JumpForce = -4;

            Assert.AreEqual(0, playerItem.JumpForce);
        }

    }
}
