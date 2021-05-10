using HMF.Thesis.Interfaces;
using HMF.Thesis.Logic;
using Moq;
using NUnit.Framework;
using UnityEngine;

namespace HMF.Thesis.Tests.Logic
{
    public class AttackLogicTest
    {
        
        [Test]
        public void AttackLogic()
        {
            //* Setup
            var itemMoq = new Mock<IItem>();
            var dummy = new GameObject();
            var stringDummy = new string[1];

            itemMoq.Setup(m => m.Use(dummy, stringDummy, new LayerMask()));

            var attack = new AttackLogic(dummy);

            //* Affect
            attack.Attack(itemMoq.Object, stringDummy, new LayerMask());

            //* Testing
            itemMoq.Verify(m => m.Use(dummy, stringDummy, new LayerMask()), Times.Once);
        }

        
    }
}
