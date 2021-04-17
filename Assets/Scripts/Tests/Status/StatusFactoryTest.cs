using NUnit.Framework;
using HMF.Thesis.Status;
using HMF.Thesis.Status.ActualStatuses;

namespace HMF.Thesis.Tests
{
    public class StatusFactoryTest
    {
        [Test]
        public void TestIfFactoryGivesBackTheRightClass()
        {
            //* Setup

            //* Affect
            var status = StatusFactory.GetStatus("Bleeding");

            //* Testing

            Assert.AreEqual("Bleeding", status.Name);
            Assert.IsInstanceOf(typeof(Bleeding), status);
        }

        [Test]
        public void TestIfFactoryGivesBackNothingWithWrongName()
        {
            //* Setup

            //* Affect
            var status = StatusFactory.GetStatus("Bleedin");

            //* Testing

            Assert.Null(status);
        }

        [Test]
        public void TestIfFactoryGivesBackNothingWithNo()
        {
            //* Setup

            //* Affect
            var status = StatusFactory.GetStatus("");

            //* Testing

            Assert.Null(status);
        }
        
    }
}
