namespace Oefening_Events
{
    public class ThreeDimensionalViewer
    {
        public string Name { get; set; } = "scherm";

        public ThreeDimensionalViewer(Model model)
        {
            model.AddObserver(ShowView);
        }

        public void ShowView(Object m, EventArgs e)
        {
            if(m is Model model)
            {
                Console.WriteLine($"{Name} meldt: getal gewijzigd: {model.Getal}");
            }

            if(e is ModelChangedEventArgs args)
            {
                Console.WriteLine($"{Name} meldt: getal gewijzigd van {args.OudGetal} naar {args.NieuwGetal}");
            }
        }
    }
}
