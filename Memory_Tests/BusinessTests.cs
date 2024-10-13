using Memory_Business;

namespace Memory_Tests
{
    public class BusinessTests
    {
        [TestCase(5)]
        [TestCase(7)]
        [TestCase(10)]
        [Test]
        public void RandomizeCards_RandomizeArrayOfCards_ArrayLengthEqualsPairs(int pairs)
        {
            //Arrange & Act
            MemoryGame game = new MemoryGame(pairs);

            //Assert
            Assert.AreEqual(game.CardsOnTable.Length, pairs * 2);
        }
    }
}