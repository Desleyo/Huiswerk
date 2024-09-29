using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Week3B_Emmer.Enums;
using Week3B_Emmer.Models;

namespace Week3B_Emmer_UnitTests.Events
{
    internal class EventTests
    {
        [TestCase(Capacities.SMALL)]
        [TestCase(Capacities.MEDIUM)]
        [TestCase(Capacities.LARGE)]
        [Test]
        public void Event_ContentEqualToCapacity_FiresFullEvent(Capacities capacity)
        {
            //Arrange
            Rainbarrel rainbarrel = new Rainbarrel(capacity);
            bool fullWasFired = false;
            rainbarrel.AddObserver(delegate { fullWasFired = true; }, true);
            bool overflowedWasFired = false;
            rainbarrel.AddObserver(delegate {  overflowedWasFired = true; }, false);

            //Act
            rainbarrel.Fill((int)capacity);

            //Assert
            Assert.IsTrue(fullWasFired);
            Assert.IsFalse(overflowedWasFired);
        }

        [TestCase(160)]
        [TestCase(180)]
        [TestCase(200)]
        [Test]
        public void Event_ContentGreaterThanCapacity_FiresOverflowedEvent(int content)
        {
            //Arrange
            Oilbarrel oilbarrel = new Oilbarrel();
            bool overflowedWasFired = false;
            oilbarrel.AddObserver(delegate { overflowedWasFired = true; }, false);
            bool fullWasFired = false;
            oilbarrel.AddObserver(delegate { fullWasFired = true; }, true);

            //Act
            oilbarrel.Content = content;

            //Assert
            Assert.IsTrue(overflowedWasFired);
            Assert.IsFalse(fullWasFired);
        }

        [Test]
        public void Event_CombineBucketsGreaterThanCapacity_FiresOverflowedEvent()
        {
            //Arrange
            Bucket bucket1 = new Bucket();
            Bucket bucket2 = new Bucket();
            bool overflowedWasFired = false;
            bucket1.AddObserver(delegate {overflowedWasFired = true; }, false);
            bool fullWasFired = false;
            bucket1.AddObserver(delegate { fullWasFired = true; }, true);

            //Act
            bucket1.Fill(10);
            bucket2.Fill(10);
            bucket1.CombineBuckets(bucket2);

            //Assert
            Assert.IsTrue(overflowedWasFired);
            Assert.IsFalse(fullWasFired);
        }

        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(-100)]
        [Test]
        public void Event_ContentEqualsZeroOrNegative_NoEventWasFired(int content)
        {
            //Arrange
            Bucket bucket = new Bucket();
            bool wasFired = false;
            bucket.AddObserver(delegate { wasFired = true; });

            //Act
            bucket.Content = content;

            //Assert
            Assert.IsFalse(wasFired);
        }
    }
}
