using Week3B_Emmer.Models;

namespace Week3B_Emmer_UnitTests.OilBarrelTests.Methods
{
    internal class OilbarrelMethodTests
    {
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void Fill_AddContent_ContentAddedSuccesfully(int amount)
        {
            //Arrange
            Oilbarrel oilbarrel = new Oilbarrel();

            //Act
            oilbarrel.Fill(amount);

            //Assert
            Assert.AreEqual(oilbarrel.Content, amount);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void Empty_RemoveContent_ContentRemovedSuccesfully(int amount)
        {
            //Arrange
            Oilbarrel oilbarrel = new Oilbarrel();

            //Act
            int currentContent = Oilbarrel.DEFAULT_CAPACITY;
            oilbarrel.Content = currentContent;
            oilbarrel.Empty(amount);

            //Assert
            Assert.AreEqual(oilbarrel.Content, currentContent - amount);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void Empty_RemoveAllContent_OilbarrelIsEmpty(int content)
        {
            //Arrange
            Oilbarrel oilbarrel = new Oilbarrel();

            //Act
            oilbarrel.Content = content;
            oilbarrel.Empty();

            //Assert
            Assert.AreEqual(oilbarrel.Content, 0);
        }
    }
}
