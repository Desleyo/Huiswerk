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

        [TestCase(5)]
        [TestCase(7)]
        [TestCase(10)]
        public void RandomizeCards_RandomizeArrayOfCards_ArrayContains2OfEachCard(int pairs)
        {
            //Arrange
            MemoryGame game = new MemoryGame(pairs);

            Dictionary<char, int> amountPerUniqueCard = new Dictionary<char, int>();
            bool amountsAreCorrect = true;

            //Act
            foreach (char card in game.CardsOnTable)
            {
                if (amountPerUniqueCard.ContainsKey(card))
                {
                    amountPerUniqueCard[card]++;
                }
                else
                {
                    amountPerUniqueCard.Add(card, 1);
                }
            }

            foreach (KeyValuePair<char, int> pair in amountPerUniqueCard)
            {
                if (pair.Value != 2)
                {
                    amountsAreCorrect = false;
                }
            }

            //Assert
            Assert.IsTrue(amountsAreCorrect);
        }
    }
}