using Memory_Business;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Memory_WpfApp
{
    public partial class GamePage : Page
    {
        //Variables for placing the cards
        private const int buttonStartingPos = -400;
        private const int addToX = 200;
        private const int addToY = 250;

        private MemoryGame game;

        private List<CardButton> cardButtons;

        private int currentGuess1 = -1;
        private int currentGuess2 = -1;

        private SolidColorBrush defaultColor = new SolidColorBrush(Colors.White);
        private SolidColorBrush foundColor = new SolidColorBrush(Colors.LightGreen);

        public GamePage(MemoryGame game)
        {
            InitializeComponent();

            this.game = game;
            cardButtons = new List<CardButton>();

            AddCardsToGrid();
        }

        private void AddCardsToGrid()
        {
            int x = buttonStartingPos;
            int y = buttonStartingPos;
            int createdCards = 0;

            for (int i = 0; i < game.CardsOnTable.Length; i++)
            {
                //Create and add buttons (cards) to the UI and cardButtonsList
                CardButton button = new CardButton(this, i, x, y);
                cardButtons.Add(button);
                grid.Children.Add(button);
                createdCards++;

                x += addToX;

                //Place cards in rows of 5
                if(createdCards % 5 == 0)
                {
                    x = buttonStartingPos;
                    y += addToY;
                    createdCards = 0;
                }
            }
        }

        public void Card_Click(Object sender, RoutedEventArgs e)
        {
            if(currentGuess1 != -1 && currentGuess2 != -1)
            {
                currentGuess1 = -1;
                currentGuess2 = -1;
                ResetCards();
            }

            CardButton card = (CardButton)sender;
            card.Content = game.CardsOnTable[card.Id];

            if (currentGuess1 == -1)
            {
                currentGuess1 = card.Id;
            }
            else if(currentGuess2 == -1 && currentGuess1 != card.Id)
            {
                currentGuess2 = card.Id;

                game.MakeGuess(currentGuess1, currentGuess2);
                if (game.GameEnded)
                {
                    Main.Visibility = Visibility.Visible;
                    Main.Content = new HighscorePage(game);
                }
            }

            card.Background = foundColor;
        }

        //Hide the cards that have been turned around, unless the card pair has been found
        private void ResetCards()
        {
            foreach(CardButton card in cardButtons)
            {
                if (!game.foundPairs.Contains(game.CardsOnTable[card.Id]))
                {
                    card.Content = "";
                    card.Background = defaultColor;
                }
            }
        }
    }
}
