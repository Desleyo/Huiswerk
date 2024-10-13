using Memory_Business;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Memory_WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
   
            PairsLabel.Content = $"Pairs (min: {MemoryGame.minPairs}, max: {MemoryGame.maxPairs})";
        }

        private void ValidatePairsTextBox(object sender, TextCompositionEventArgs e)
        {
            //Only allow numbers (and whitespaces) in the textbox
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PlayGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PairsTextBox.Text))
            {
                return;
            }

            string removedWhitespace = Regex.Replace(PairsTextBox.Text, @"\s+", "");
            int pairs = int.Parse(removedWhitespace);

            Main.Content = new GamePage(new MemoryGame(pairs));
            Main.Visibility = Visibility.Visible;
        }
    }
}