using Memory_Business;
using Memory_DataAccess;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Memory_WpfApp
{
    public partial class HighscorePage : Page
    {
        private MemoryGame game;
        private MemoryService service;

        public HighscorePage(MemoryGame game)
        {
            InitializeComponent();

            this.game = game;
            service = new MemoryService(new MemoryRepository());

            int score = game.CalculateScore();
            ScoreLabel.Content = $"Your score is: {score}";

            if (service.CheckIfNewHighscore(score))
            {
                ShowNewHighscoreUI(Visibility.Visible);
            }
            else
            {
                ShowHighscores();
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string name = Regex.Replace(NameTextBox.Text, @"\s+", "");

            if(string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                NameRequirementsLabel.Visibility = Visibility.Visible;
                return;
            }

            Highscore highscore = new Highscore() { Name = name, Score = game.CalculateScore(), AmountOfCards = game.CardsOnTable.Length };
            service.InsertNewHighscore(highscore);

            ShowNewHighscoreUI(Visibility.Hidden);
            ShowHighscores();
        }

        private void ShowHighscores()
        {
            ICollection<Highscore> highscores = service.GetHighscores();

            CurrentHighscoresLabel.Visibility = Visibility.Visible;
            CurrentHighscoresLabel.Content = $"These are the current top {highscores.Count}:";

            int x = 175;
            int y = 150;
            foreach (Highscore highscore in highscores)
            {
                Label label = new Label();
                label.Width = 300;
                label.Margin = new Thickness(x, y, 0, 0);
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.Content = highscore.ToString() + " (cards)";

                grid.Children.Add(label);

                y += 35;
            }
        }

        private void ShowNewHighscoreUI(Visibility visibility)
        {
            NewHighscoreLabel.Visibility = visibility;
            NameTextBox.Visibility = visibility;
            SubmitButton.Visibility = visibility;

            if(visibility == Visibility.Hidden)
            {
                NameRequirementsLabel.Visibility = visibility;
            }
        }
    }
}
