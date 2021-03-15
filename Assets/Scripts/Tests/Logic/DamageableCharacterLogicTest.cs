using NUnit.Framework;
using HMF.Thesis.Logic;
using HMF.Thesis.Interfaces;
using Moq;

namespace HMF.Thesis.Tests.Logic
{
    /// Tets for the Damageable class.
    public class DamageableCharacterLogicTest
    {
        /// Test for TakeDamage without an input damage.
        [Test]
        public void TakeDamage()
        {
            //* Setup
            var characterMoq = new Mock<ICharacter>();
            characterMoq.SetupProperty(e => e.Health, 5);

            var damageable = new DamageableCharacterLogic(characterMoq.Object);

            //* Affect
            damageable.TakeDamage();

            //* Testing
            Assert.AreEqual(4, characterMoq.Object.Health);
            
        }

        /// Test for TakeDamage with an input damage.
        [Test]
        public void TakeDamageWithInputParameter()
        {
            //* Setup
            var characterMoq = new Mock<ICharacter>();
            characterMoq.SetupProperty(e => e.Health, 5);

            var damageable = new DamageableCharacterLogic(characterMoq.Object);

            //* Affect
            damageable.TakeDamage(2);

            //* Testing
            Assert.AreEqual(3, characterMoq.Object.Health);
            
        }
    }
}
