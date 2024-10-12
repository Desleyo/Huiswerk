using System.Diagnostics;

namespace Memory_Business
{
    public class MemoryGame
    {
        //The cards that will be used in play
        private readonly List<char> cards = new List<char>() { '!', '!', '@', '@', '#', '#', '$', '$', '%', '%' };

        //The array that represents the current game
        public char[] CardsOnTable { get; private set; }

        //The pairs that have already been found
        public List<char> foundPairs { get; private set; }

        private int amountOfTries = 0;

        public bool GameEnded { get; private set; } = false;

        public MemoryGame()
        {
            CardsOnTable = new char[cards.Count];
            foundPairs = new List<char>();

            RandomizeCards();
        }

        //Randomize the positions of the cards in play
        public void RandomizeCards()
        {
            for (int i = 0; i < CardsOnTable.Length; i++)
            {
                int randomCardPos = Random.Shared.Next(0, cards.Count); 
                CardsOnTable[i] = cards[randomCardPos];
                cards.RemoveAt(randomCardPos);
            }
        }

        public void MakeGuess(int guess1, int guess2)
        { 
            if(guess1 >= CardsOnTable.Length || guess2 >= CardsOnTable.Length)
            {
                return;
            }

            if (CardsOnTable[guess1] == CardsOnTable[guess2] && !foundPairs.Contains(CardsOnTable[guess1]))
            {
                foundPairs.Add(CardsOnTable[guess1]);

                if(foundPairs.Count == CardsOnTable.Length / 2)
                {
                    GameEnded = true;
                }
            }

            amountOfTries++;
        }

        public int CalculateScore()
        {
            int amountOfCards = CardsOnTable.Length;
            TimeSpan timeSpan = DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime();
            int timeElapsed = (int)Math.Round(timeSpan.TotalSeconds);

            return (int)Math.Round(((Math.Pow(amountOfCards, 2)) / (timeElapsed * amountOfTries)) * 1000);
        }
    }
}
