using Week3B_Emmer.Models;

namespace Week3B_Emmer_UnitTests.OilBarrelTests.Values
{
    internal class OilbarrelValuetests
    {
        [TestCase(-1)]
        [TestCase(-50)]
        [TestCase(-100)]
        [Test]
        public void Oilbarrel_NegativeContent_ContentRemainsZero(int content)
        {
            //Arrange
            Oilbarrel oilbarrel = new Oilbarrel();

            //Act
            oilbarrel.Content = content;

            //Assert
            Assert.AreEqual(oilbarrel.Content, 0);
        }

        [Test]
        public void Oilbarrel_ReadCapacity_ReadsCapacitySuccesfully()
        {
            //Arange and Act
            Oilbarrel oilbarrel = new Oilbarrel();

            //Assert
            Assert.AreEqual(oilbarrel.Capacity, Oilbarrel.DEFAULT_CAPACITY);
        }

        [Test]
        public void Oilbarrel_ReadContent_ContentShouldReadZero()
        {
            //Arrange and Act
            Oilbarrel oilbarrel = new Oilbarrel();

            //Assert
            Assert.AreEqual(oilbarrel.Content, 0);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void Oilbarrel_SetContent_ContentSetSuccesfully(int content)
        {
            //Arrange
            Oilbarrel oilbarrel = new Oilbarrel();

            //Act
            oilbarrel.Content = content;

            //Assert
            Assert.AreEqual(oilbarrel.Content, content);
        }
    }
}
