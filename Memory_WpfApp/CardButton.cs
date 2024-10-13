using System.Windows;
using System.Windows.Controls;

namespace Memory_WpfApp
{
    public class CardButton : Button
    {
        public int Id { get; private set; }

        public CardButton(GamePage page, int id, int x, int y)
        {
            Id = id;

            Name = $"CardButton{id}";
            Height = 100;
            Width = 75;
            Margin = new Thickness(x, y, 0, 0);
            FontSize = 20;
            Click += page.Card_Click;
        }
    }
}
