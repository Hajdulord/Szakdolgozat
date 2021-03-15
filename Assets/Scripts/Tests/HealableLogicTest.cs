using NUnit.Framework;
using HMF.Thesis.Interfaces;
using HMF.Thesis.Logic;
using Moq;

namespace HMF.Thesis.Tests
{
    public class HealableLogicTest
    {
        [Test]
        public void HealWithDefaultValue()
        {
            //* Setup
            var characterMoq = new Mock<ICharacter>();
            characterMoq.SetupProperty(e => e.Health, 5);

            var healable = new HealableLogic(characterMoq.Object);

            //* Affect
            healable.Heal();

            //* Testing
            Assert.AreEqual(6, characterMoq.Object.Health);
        }

        [Test]
        public void HealWithSetValue()
        {
            //* Setup
            var characterMoq = new Mock<ICharacter>();
            characterMoq.SetupProperty(e => e.Health, 5);

            var healable = new HealableLogic(characterMoq.Object);

            //* Affect
            healable.Heal(2);

            //* Testing
            Assert.AreEqual(7, characterMoq.Object.Health);
        }
    }
}
