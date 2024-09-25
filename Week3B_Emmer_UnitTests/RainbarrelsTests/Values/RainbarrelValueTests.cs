using Week3B_Emmer.Enums;
using Week3B_Emmer.Models;

namespace Week3B_Emmer_UnitTests.RainbarrelsTests.Values
{
    internal class RainbarrelValueTests
    {
        [TestCase(-1)]
        [TestCase(-50)]
        [TestCase(-100)]
        [Test]
        public void Rainbarrel_NegativeContent_ContentRemainsZero(int content)
        {
            //Arrange
            Rainbarrel rainbarrel = new Rainbarrel(Capacities.SMALL);

            //Act
            rainbarrel.Content = content;

            //Assert
            Assert.AreEqual(rainbarrel.Content, 0);
        }

        [TestCase(Capacities.SMALL)]
        [TestCase(Capacities.MEDIUM)]
        [TestCase(Capacities.LARGE)]
        [Test]
        public void Rainbarrel_ReadCapacity_ReadsCapacitySuccesfully(Capacities capacity)
        {
            //Arange and Act
            Rainbarrel rainbarrel = new Rainbarrel(capacity);

            //Assert
            Assert.AreEqual(rainbarrel.Capacity, (int)capacity);
        }

        [Test]
        public void Rainbarrel_ReadContent_ContentShouldReadZero()
        {
            //Arrange and Act
            Rainbarrel rainbarrel = new Rainbarrel(Capacities.SMALL);

            //Assert
            Assert.AreEqual(rainbarrel.Content, 0);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void Rainbarrel_SetContent_ContentSetSuccesfully(int content)
        {
            //Arrange
            Rainbarrel rainbarrel = new Rainbarrel(Capacities.SMALL);

            //Act
            rainbarrel.Content = content;

            //Assert
            Assert.AreEqual(rainbarrel.Content, content);
        }

        [Test]
        public void Rainbarrel_InvalidCapacity_SetCapacityToSmall()
        {
            //Arrange and Act
            Rainbarrel rainbarrel = new Rainbarrel(Capacities.SMALL + 100);

            //Assert
            Assert.AreEqual(rainbarrel.Capacity, (int)Capacities.SMALL);
        }
    }
}
