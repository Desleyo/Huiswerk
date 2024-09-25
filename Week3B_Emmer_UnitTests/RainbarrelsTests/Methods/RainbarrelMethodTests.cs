using Week3B_Emmer.Models;
using Week3B_Emmer.Enums;

namespace Week3B_Emmer_UnitTests.RainbarrelsTests.Methods
{
    internal class RainbarrelMethodTests
    {
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void Fill_AddContent_ContentAddedSuccesfully(int amount)
        {
            //Arrange
            Rainbarrel rainbarrel = new Rainbarrel(Capacities.SMALL);

            //Act
            rainbarrel.Fill(amount);

            //Assert
            Assert.AreEqual(rainbarrel.Content, amount);
        }

        [TestCase(Capacities.SMALL, 1)]
        [TestCase(Capacities.MEDIUM, 5)]
        [TestCase(Capacities.LARGE, 10)]
        [Test]
        public void Empty_RemoveContent_ContentRemovedSuccesfully(Capacities capacity, int amount)
        {
            //Arrange
            Rainbarrel rainbarrel = new Rainbarrel(capacity);

            //Act
            int currentContent = (int)capacity;
            rainbarrel.Content = currentContent;
            rainbarrel.Empty(amount);

            //Assert
            Assert.AreEqual(rainbarrel.Content, currentContent - amount);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void Empty_RemoveAllContent_RainbarrelIsEmpty(int content)
        {
            //Arrange
            Rainbarrel rainbarrel = new Rainbarrel(Capacities.SMALL);

            //Act
            rainbarrel.Content = content;
            rainbarrel.Empty();

            //Assert
            Assert.AreEqual(rainbarrel.Content, 0);
        }
    }
}
