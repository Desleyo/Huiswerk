using Memory_Business;
using Memory_DataAccess;
using System.Text.RegularExpressions;

namespace Memory_ConsoleApp
{
    internal class Program
    {
        private static MemoryGame? game;

        private static int currentGuess1 = -1;
        private static int currentGuess2 = -1;

        static void Main(string[] args)
        {
            game = new MemoryGame(5);

            PlayGame();
        }

        private static void PlayGame()
        {
            //Main flow of the game
            while (!game.GameEnded)
            {
                PrintCards();

                try
                {
                    Console.WriteLine("What is your first guess?");
                    currentGuess1 = int.Parse(Console.ReadLine());

                    Console.WriteLine("What is your second guess?");
                    currentGuess2 = int.Parse(Console.ReadLine());

                    if (currentGuess1 != currentGuess2)
                    {
                        game.MakeGuess(currentGuess1, currentGuess2);
                    }
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

            DisplayHighscores();
        }

        private static void DisplayHighscores()
        {
            //Used for data access
            MemoryService service = new MemoryService(new MemoryRepository());

            int currentScore = game.CalculateScore();

            Console.WriteLine("Congratulations you have won the game of memory!");
            Console.WriteLine($"Your score is: {currentScore}\n");

            //Check and potentially save new highscore
            if (service.CheckIfNewHighscore(currentScore))
            {
                Console.WriteLine("You have achieved a new highscore!");

                string name = "";
                while (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                {
                    Console.WriteLine("Please submit your name for your new highscore");

                    name = Regex.Replace(Console.ReadLine(), @"\s+", "");
                }

                Highscore highscore = new Highscore() { Name = name, Score = currentScore, AmountOfCards = game.CardsOnTable.Length };
                service.InsertNewHighscore(highscore);
                Console.Clear();
            }

            //Display top highscores
            ICollection<Highscore> highscores = service.GetHighscores();
            Console.WriteLine($"These are the current top {highscores.Count} highscores:");
            foreach (Highscore highscore in highscores)
            {
                Console.WriteLine(highscore.ToString() + " (cards)");
            }
        }

        //Prints all the cards upside down, except for the current guesses
        private static void PrintCards(int guess1 = -1, int guess2 = -1)
        {
            Console.WriteLine("\n[0][1][2][3][4]");

            for (int i = 0; i < game?.CardsOnTable.Length; i++)
            {
                if (i == game?.CardsOnTable.Length / 2)
                {
                    Console.WriteLine();
                }

                if (i == guess1 || i == guess2 || game.foundPairs.Contains(game.CardsOnTable[i]))
                {
                    Console.Write($" {game?.CardsOnTable[i]} ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" X ");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\n[5][6][7][8][9]\n");
        }
    }
}
