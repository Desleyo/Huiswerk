using Memory_Business;

namespace Memory_ConsoleApp
{
    internal class Program
    {
        private static MemoryGame? game;

        private static int currentGuess1 = -1;
        private static int currentGuess2 = -1;

        static void Main(string[] args)
        {
            game = new MemoryGame();

            while (!game.GameEnded)
            {
                PrintCards();

                try
                {
                    Console.WriteLine("What is your first guess?");
                    currentGuess1 = int.Parse(Console.ReadLine());

                    Console.WriteLine("What is your second guess?");
                    currentGuess2 = int.Parse(Console.ReadLine());

                    game.MakeGuess(currentGuess1, currentGuess2);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid guess. The guess was forfeit");
                    currentGuess1 = -1;
                    currentGuess2 = -1;
                }

                PrintCards(currentGuess1, currentGuess2);

                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("Congratulations you have won the game of memory!");
            Console.WriteLine($"Your score is: {game.CalculateScore()}");
        }

        //Prints all the cards upside down, except for the current guesses
        private static void PrintCards(int guess1 = -1, int guess2 = -1)
        {
            Console.WriteLine("\n[0][1][2][3][4]");

            for(int i = 0; i < game?.CardsOnTable.Length; i++)
            {
                if(i == game?.CardsOnTable.Length / 2)
                {
                    Console.WriteLine();
                }

                if(i == guess1 ||  i == guess2 || game.foundPairs.Contains(game.CardsOnTable[i]))
                {
                    Console.Write($" {game?.CardsOnTable[i]} ");
                }
                else
                {
                    Console.Write(" X ");
                }
            }

            Console.WriteLine("\n[5][6][7][8][9]\n");
        }
    }
}
