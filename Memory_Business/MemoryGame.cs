using System.Diagnostics;

namespace Memory_Business
{
    public class MemoryGame
    {
        public static readonly int minPairs = 2;
        public static readonly int maxPairs = 10;

        //The cards that will be used in play
        private readonly List<char> cards = new List<char>() { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };

        //The array that represents the current game
        public char[] CardsOnTable { get; private set; }

        //The pairs that have already been found
        public List<char> foundPairs { get; private set; }

        private int amountOfTries = 0;

        public bool GameEnded { get; private set; } = false;

        private DateTime startOfGame;
        private DateTime endOfGame;

        public MemoryGame(int pairs)
        {
            //Make sure the amount of pairs is within min and max;
            pairs = pairs < minPairs ? minPairs : pairs > maxPairs ? maxPairs : pairs;

            CardsOnTable = new char[pairs * 2];
            foundPairs = new List<char>();

            RandomizeCards(pairs);

            startOfGame = DateTime.Now;
        }

        //Randomize the positions of the cards in play
        public void RandomizeCards(int pairs)
        {
            //Extract the cards that are needed from the cards list, instead of using every possible card
            List<char> cardsToShuffle = new List<char>();
            for (int i = 0; i < pairs; i++)
            {
                //Add the cards twice since we need 2 to make a pair
                cardsToShuffle.Add(cards[i]);
                cardsToShuffle.Add(cards[i]);
            }

            //Shuffle the cards into the CardsOnTable list
            for (int i = 0; i < CardsOnTable.Length; i++)
            {
                int randomCardPos = Random.Shared.Next(0, cardsToShuffle.Count);
                CardsOnTable[i] = cardsToShuffle[randomCardPos];
                cardsToShuffle.RemoveAt(randomCardPos);
            }
        }

        public void MakeGuess(int guess1, int guess2)
        {
            if (guess1 >= CardsOnTable.Length || guess2 >= CardsOnTable.Length)
            {
                return;
            }

            if (CardsOnTable[guess1] == CardsOnTable[guess2] && !foundPairs.Contains(CardsOnTable[guess1]))
            {
                foundPairs.Add(CardsOnTable[guess1]);

                if (foundPairs.Count == CardsOnTable.Length / 2)
                {
                    GameEnded = true;
                    endOfGame = DateTime.Now;
                }
            }

            amountOfTries++;
        }

        public int CalculateScore()
        {
            int amountOfCards = CardsOnTable.Length;
            TimeSpan timeSpan = endOfGame - startOfGame;
            int timeElapsed = (int)Math.Round(timeSpan.TotalSeconds);

            return (int)Math.Round(((Math.Pow(amountOfCards, 2)) / (timeElapsed * amountOfTries)) * 1000);
        }
    }
}
